using System;
using System.Net.Http;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController:ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        
        internal Int32 IGuid => !User.Identity.IsAuthenticated
            ? 0
            : Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}