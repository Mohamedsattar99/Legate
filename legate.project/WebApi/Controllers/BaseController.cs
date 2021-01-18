using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Controllers {
    [ApiController]
    [Route ("api/[controller]/[action]")]
       //TODO: remove the api from the route
        public abstract class BaseController : Controller {
        private IMediator mediatR;
        protected IMediator Mediator => mediatR ??= HttpContext.RequestServices.GetService<IMediator> ();
    }
}