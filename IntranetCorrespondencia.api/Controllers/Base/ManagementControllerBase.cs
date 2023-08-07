using Microsoft.AspNetCore.Mvc;
using ControllerBase = IntranetCorrespondencia.api.Controllers.Base.ControllerBase;

namespace IntranetCorrespondencia.api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]/")]
    public class ManagementControllerBase : ControllerBase
    {

    }
}