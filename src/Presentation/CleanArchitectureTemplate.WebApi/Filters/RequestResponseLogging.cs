using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;


namespace CleanArchitectureTemplate.WebApi.Filters
{
    public class RequestResponseLogging
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public RequestResponseLogging(RequestDelegate next,
                                                ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory
                      .CreateLogger<RequestResponseLogging>();
            //_recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
        }
        public async Task Invoke(HttpContext context)
        {
            StringBuilder builder = new StringBuilder();

            //await LogRequest(context, builder);
            //await LogResponse(context, builder);

            _logger.LogInformation(builder.ToString());
        }

        //private async Task LogRequest(HttpContext context, StringBuilder builder)
        //{
        //    context.Request.EnableBuffering();

        //    await using var requestStream = _recyclableMemoryStreamManager.GetStream();

        //    if (context.Request.Body.CanSeek)
        //        context.Request.Body.Seek(0, SeekOrigin.Begin);

        //    await context.Request.Body.CopyToAsync(requestStream);

        //    builder.AppendLine(Environment.NewLine);
        //    builder.AppendLine($"{context.Request.Method} {context.Request.Path} ");
        //    foreach (var header in context.Request.Headers)
        //    {
        //        builder.AppendLine($"{header.Key}:{header.Value}");
        //    }
        //    builder.AppendLine(Environment.NewLine);

        //    var body = await requestStream.ReadStreamInChunksAsync();
        //    if (context.Request.Body.CanSeek)
        //        context.Request.Body.Seek(0, SeekOrigin.Begin);

        //    builder.AppendLine($"{body}");
        //}
        //private async Task LogResponse(HttpContext context, StringBuilder builder)
        //{
        //    var originalBodyStream = context.Response.Body;

        //    await using var responseBody = _recyclableMemoryStreamManager.GetStream();

        //    context.Response.Body = responseBody;

        //    await _next(context);

        //    context.Response.Body.Seek(0, SeekOrigin.Begin);

        //    var text = await new StreamReader(context.Response.Body).ReadToEndAsync();

        //    context.Response.Body.Seek(0, SeekOrigin.Begin);

        //    builder.AppendLine(Environment.NewLine);
        //    builder.AppendLine(" | ");
        //    builder.AppendLine(Environment.NewLine);
        //    foreach (var header in context.Response.Headers)
        //    {
        //        builder.AppendLine($"{header.Key}:{header.Value}");
        //    }
        //    builder.AppendLine(Environment.NewLine);
        //    builder.AppendLine($"{text}");
        //    builder.AppendLine(Environment.NewLine);

        //    await responseBody.CopyToAsync(originalBodyStream);
        //}

    }

    public static class RequestResponseLoggingExtensions
    {
        public static IApplicationBuilder UseHttpLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestResponseLogging>();
        }
    }
}
