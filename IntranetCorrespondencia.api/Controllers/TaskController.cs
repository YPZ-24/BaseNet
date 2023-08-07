using IntranetCorrespondencia.api.Controllers.Base;
using IntranetCorrespondencia.api.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace IntranetCorrespondencia.api.Controllers
{
    [ApiVersion("1.0")]
    public class TaskController : ManagementControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetTask()
        {
            List<GetTaskResponse> resultData = await Mediator.Send(new GetTaskRequest());
            return Ok(new ApiResponse<GetTaskResponse>(200, "Tareas encontradas", resultData));
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskRequest request)
        {
            CreateTaskResponse resultData = await Mediator.Send(request);
            return Ok(new ApiResponse<CreateTaskResponse>(
                StatusCodes.Status201Created, 
                "Tarea creada", 
                resultData
            ));
        }
    }
}