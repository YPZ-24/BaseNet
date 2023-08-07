using MediatR;

namespace IntranetCorrespondencia.api.Handlers
{
    public class GetTaskResponse: IRequest
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
