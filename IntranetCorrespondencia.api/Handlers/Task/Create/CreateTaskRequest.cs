using MediatR;

namespace IntranetCorrespondencia.api.Handlers
{
    public class CreateTaskRequest: IRequest<CreateTaskResponse>
    {
        public string Description { get; set; }
    }
}
