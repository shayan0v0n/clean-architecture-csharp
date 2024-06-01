using AppSimcard.Domain.Enum;
using CleanArchitectureTemplate.Domain.DomainServiceResult;
using CleanArchitectureTemplate.Domain.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.WebApi.Filters
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public CustomExceptionHandlerMiddleware(RequestDelegate next,
                                                ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory
                      .CreateLogger<RequestResponseLogging>();
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            await this.ManageLog(httpContext, ex);

            var result = new DomainServiceRespondResult<string>();
            switch (ex)
            {

                case DbUpdateConcurrencyException _:
                    result.SetResult(ex.Message, ResultStatus.Conflict, Messages.ConcurrencyError);
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
                case SecurityTokenExpiredException _:
                    result.SetResult(ex.Message, ResultStatus.Unauthorize, Messages.Unauthorize);
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;
                case ArgumentException _:
                    result.SetResult(ex.Message, ResultStatus.BadRequest, Messages.BadRequest);
                    httpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                    break;
                default:
                    result.SetResult(ex.Message, ResultStatus.Error, Messages.Error);
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            string response = JsonConvert.SerializeObject(result).ToLower();
            await httpContext.Response.WriteAsync(response);
            httpContext.Response.ContentType = "application/json";

        }

        private async Task ManageLog(HttpContext httpContext, Exception ex)
        {
            StringBuilder builder = new StringBuilder(Environment.NewLine);


            _logger.LogError(ex, builder.ToString());
        }


    }
    public static class CustomExceptionHandlerExtension
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}