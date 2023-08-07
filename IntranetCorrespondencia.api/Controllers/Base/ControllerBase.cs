using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IntranetCorrespondencia.api.Controllers.Base
{
    public abstract class ControllerBase : Controller
    {
        private IMediator _Mediator;
        protected IMediator Mediator
        {
            get
            {
                return _Mediator ?? (_Mediator = HttpContext.RequestServices.GetService<IMediator>());
            }
        }
    }
}
