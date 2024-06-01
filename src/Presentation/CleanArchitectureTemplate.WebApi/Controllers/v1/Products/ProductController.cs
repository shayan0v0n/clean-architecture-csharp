using AppSimcard.API.Response;
using AppSimcard.Security.RolesConst;
using CleanArchitectureTemplate.WebApi.Filters;
using CleanArchtectureTemplate.WebApi.Controllers.v1.Users.Requests;
using CleanTemplate.Application.Products.Queries;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;

namespace CleanArchtectureTemplate.WebApi.Controllers.v1.Products
{
    public class ProductController : BaseController
    {
        [HttpPost("products")]
        [SwaggerOperation("sign up user")]
        [SecurityFilter(ApplicationRoles.ApplicationUserRole)]
        [AllowAnonymous]
        public virtual async Task<IActionResult> Products( CancellationToken cancellationToken)
        {
            
            var result = await Mediator.Send(new GetProductQuery(), cancellationToken);
            return ResponseUtil.ResultMessage(result);
        }
    }


}
