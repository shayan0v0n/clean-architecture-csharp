using CleanArchitectureTemplate.Domain.DomainServiceResult;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSimcard.API.Response
{
    public static class ResponseUtil
    {
        public static IActionResult ResultMessage<TViewModel>(TViewModel data)
        {
            var result = new DomainServiceResult<TViewModel>() { Result = data };
            return new JsonResult(result);
        }
        public static IActionResult ResultMessage<TViewModel>(this IDomainServiceRespondResult<TViewModel> domainServiceResult)
        {
            return new JsonResult(domainServiceResult);
        }
    }
}
