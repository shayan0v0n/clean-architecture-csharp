using AppSimcard.Domain.Enum;
using CleanArchitectureTemplate.Domain.DomainServiceResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Net;

namespace CleanArchitectureTemplate.WebApi.Filters
{
    public class LockUserFilter : ActionFilterAttribute
    {
        private readonly IDistributedCache Cache;
        private string _userName = string.Empty;

        public LockUserFilter(IDistributedCache cache)
        {
            Cache = cache;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var remoteIp = context.HttpContext.Connection.RemoteIpAddress.ToString();
            var route = context.RouteData.Values;

            switch (GetRouteRequest(route))
            {
                case "Login":
                    {
                        var dto = context.ActionArguments["dto"] as LoginDTO;
                        _userName = dto.UserName;
                        break;
                    }
                default:
                    break;
            }

            var detailUserEmail = Cache.GetString(_userName + GetRouteRequest(route));
            var detailUserIP = Cache.GetString(remoteIp + GetRouteRequest(route));

            if (!string.IsNullOrEmpty(detailUserEmail) || !string.IsNullOrEmpty(detailUserIP))
            {
                bool isValid = true;
                if (!string.IsNullOrEmpty(detailUserEmail))
                    isValid = JsonConvert.DeserializeObject<RedisDetailModel>(detailUserEmail).Count >= 5 ? false : true;
                if (!string.IsNullOrEmpty(detailUserIP))
                    isValid = JsonConvert.DeserializeObject<RedisDetailModel>(detailUserIP).Count >= 5 ? false : true;

                if (!isValid)
                {
                    context.Result = new JsonResult(new { Status = HttpStatusCode.Locked, Message = Messages.Locked.GetDescription() });
                }
            }

        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // our code after action executes

            var res = (Microsoft.AspNetCore.Mvc.JsonResult)context.Result;
            var resultStr = new DomainServiceRespondResult<string>();
            var resultBl = new DomainServiceRespondResult<bool>();
            GetResultResponse(res, ref resultStr, ref resultBl);


            var route = context.RouteData.Values;

            var requestRoute = GetRouteRequest(route);

            switch (requestRoute)
            {
                case "Login":
                    {
                        if (resultStr.Status != ResultStatus.Success)
                        {
                            InsertInCach(context, requestRoute, LockType.IP);
                            InsertInCach(context, requestRoute, LockType.UserName);

                        }

                        break;
                    }
                default:
                    break;
            }

        }
        public void GetResultResponse(JsonResult res, ref DomainServiceRespondResult<string> resultStr, ref DomainServiceRespondResult<bool> resultBl)
        {

            if (res.Value is DomainServiceRespondResult<string>)
            {
                resultStr = (DomainServiceRespondResult<string>)res.Value;
            }
            else if (res.Value is DomainServiceRespondResult<bool>)
            {
                resultBl = (DomainServiceRespondResult<bool>)res.Value;
            }
        }
        public void InsertInCach(ActionExecutedContext context, string requestRoute, LockType lockType)
        {
            string keyRedis = string.Empty;
            if (lockType == LockType.IP)
            {
                keyRedis = context.HttpContext.Connection.RemoteIpAddress.ToString();
            }
            else if (lockType == LockType.UserName)
            {
                keyRedis = _userName;
            }


            var detailUser = Cache.GetString(keyRedis + requestRoute);

            if (!string.IsNullOrEmpty(detailUser))
            {
                UserExistInCach(detailUser, context, keyRedis, requestRoute);
            }
            else
            {
                UserNotExistInCach(keyRedis, requestRoute);
            }
        }
        public string GetRouteRequest(RouteValueDictionary route)
        {
            object controller, action;

            route.TryGetValue("action", out action);
            return action.ToString();
        }
        public void UserExistInCach(string detailUser, ActionExecutedContext context, string keyRedis, string requestRoute)
        {
            var _record = JsonConvert.DeserializeObject<RedisDetailModel>(detailUser);

            if (_record.Count >= 5)
            {
                context.Result = new JsonResult(new { Status = HttpStatusCode.Locked, Message = Messages.Locked });
            }
            else
            {
                _record.Count += 1;

                var json = JsonConvert.SerializeObject(_record);

                if (_record.Count == 5)
                {
                    var cacheOptions = new DistributedCacheEntryOptions();
                    cacheOptions.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
                    Cache.SetString(keyRedis + requestRoute, json, cacheOptions);

                }
                else
                    Cache.SetString(keyRedis + requestRoute, json);

            }
        }
        public void UserNotExistInCach(string keyRedis, string requestRoute)
        {
            var model = new RedisDetailModel();

            model.Count = 1;
            model.Key = keyRedis;
            model.Time = DateTime.Now;

            model.Route = requestRoute;

            var cacheOptions = new DistributedCacheEntryOptions();
            cacheOptions.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));

            var json = JsonConvert.SerializeObject(model);

            Cache.SetString(keyRedis + model.Route, json, cacheOptions);
        }
    }
}
