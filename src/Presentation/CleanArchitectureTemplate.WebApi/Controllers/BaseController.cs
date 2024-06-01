using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchtectureTemplate.WebApi.Controllers
{
    
    [Authorize]
    //[Route("api/v{version:apiVersion}/[controller]")]
    public class BaseController : ControllerBase
    {
        protected IServiceProvider Resolver => HttpContext.RequestServices;

        protected T GetService<T>()
        {
            return Resolver.GetService<T>();
        }

        protected IMediator Mediator => GetService<IMediator>();

        protected ILogger Logger => GetService<ILogger>();
    }
}
