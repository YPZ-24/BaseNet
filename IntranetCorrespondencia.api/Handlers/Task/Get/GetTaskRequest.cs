using MediatR;

namespace IntranetCorrespondencia.api.Handlers
{
    public class GetTaskRequest: IRequest<List<GetTaskResponse>>
    {
        public GetTaskRequest() { }
    }
}
