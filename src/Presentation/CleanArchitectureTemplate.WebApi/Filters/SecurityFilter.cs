using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System.Linq;
using System.Net;
using CleanArchitectureTemplate.Shared.Security.JwtToken;
using CleanArchitectureTemplate.Domain.Enums;
using CleanArchitectureTemplate.Shared.Extensions;
using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Repositories;

namespace CleanArchitectureTemplate.WebApi.Filters
{
    public class SecurityFilter : ActionFilterAttribute
    {
        private readonly string Role;

        public SecurityFilter(string role)
        {
            Role = role;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues autorizationHeader);
            if (string.IsNullOrEmpty(autorizationHeader))
            {
                context.Result = new JsonResult(new { Status = HttpStatusCode.Unauthorized, Message = Messages.NotLogin.GetDescription() });
            }
            else
            {
                string token = autorizationHeader.ToString().Replace("Bearer ", string.Empty);

                var principale = ValidateToken.GetValidToken(token);
                if (principale != null)
                {
                    var claims = ValidateToken.GetClaims(principale);
                    if (claims.Count() > 0)
                    {
                        var claim = claims.Where(c => c.Type == "UserId").FirstOrDefault();
                        string userId = claim.Value;


                        var userRoleManager = (IUserRoleRepositoryAsync)context.HttpContext.RequestServices.GetService(typeof(IUserRoleRepositoryAsync));
                        string roleId = userRoleManager.GetRoleByName(Role);
                        var IsAccess = userRoleManager.IsInRole(userId, roleId);

                        if (IsAccess)
                        {
                            var userContext = (IUserContext)context.HttpContext.RequestServices.GetService(typeof(IUserContext));
                            userContext.Id = userId;
                            userContext.RoleId = roleId;
                            return;
                        }
                        else
                        {
                            context.Result = new JsonResult(new { Status = HttpStatusCode.Unauthorized, Message = Messages.Unauthorize.GetDescription() });
                        }
                    }
                }
                else
                {
                    context.Result = new JsonResult(new { Status = HttpStatusCode.Unauthorized, Message = Messages.NotLogin.GetDescription() });
                }
            }
        }
    }
}
