using AppSimcard.API.Response;
using AppSimcard.Security.RolesConst;
using CleanArchitectureTemplate.Application.Features.Users.Commands.RegisterWithUserPass;
using CleanArchitectureTemplate.WebApi.Filters;
using CleanArchtectureTemplate.WebApi.Controllers.v1.Users.Requests;
using CleanTemplate.Application.Users.Command.Login;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CleanArchtectureTemplate.WebApi.Controllers.v1.Users
{
    //[ApiVersion("1")]
    //[SecurityFilter(ApplicationRoles.ApplicationUserRole)]

    public class UserController : BaseController
    {
        [HttpPost("Register")]
        [SwaggerOperation("register user")]
        [AllowAnonymous]
        public virtual async Task<IActionResult> RegisterAsync(SingUpRequest request, CancellationToken cancellationToken)
        {
            var command = request.Adapt<CreateUserCommand>(); 
            var result = await Mediator.Send(command, cancellationToken);
            return  ResponseUtil.ResultMessage(result);
        }

        [HttpPost("Login")]
        [SwaggerOperation("login user")]
        [AllowAnonymous]
        public virtual async Task<IActionResult> LoginAsync(LoginRequest request, CancellationToken cancellationToken)
        {
            var command = request.Adapt<GetProductQuery>();
            var result = await Mediator.Send(command, cancellationToken);
            return ResponseUtil.ResultMessage(result);
        }

        //[HttpPost("login")]
        //[SwaggerOperation("login by username and password")]
        //[AllowAnonymous]
        //public virtual async Task<ApiResult<LoginResponse>> LoginAsync([FromForm] LoginRequest request, CancellationToken cancellationToken)
        //{
        //    var command = request.Adapt<LoginCommand>();

        //    var result = await Mediator.Send(command, cancellationToken);
        //    return new ApiResult<LoginResponse>(result);
        //}

        //[HttpPost("refreshToken")]
        //[SwaggerOperation("get new refresh and access token")]
        //[AllowAnonymous]
        //public virtual async Task<ApiResult<RefreshTokenResponse>> RefreshTokenAsync([FromBody] RefreshTokenRequest request, CancellationToken cancellationToken)
        //{
        //    var command = request.Adapt<RefreshTokenCommand>();

        //    var result = await Mediator.Send(command, cancellationToken);
        //    return new ApiResult<RefreshTokenResponse>(result);
        //}
        //}
    }
}
