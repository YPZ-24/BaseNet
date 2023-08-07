using IntranetCorrespondencia.Entities.Interfaces;
using MediatR;
using AutoMapper;

namespace IntranetCorrespondencia.api.Handlers
{
    public class GetTaskHandler : IRequestHandler<GetTaskRequest, List<GetTaskResponse>>
    {
        readonly ITaskRepository TaskRepository;
        readonly IMapper Mapper;

        public GetTaskHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            TaskRepository = taskRepository;
            Mapper = mapper;
        }

        public Task<List<GetTaskResponse>> Handle(GetTaskRequest request, CancellationToken cancellationToken)
        {
            List<Entities.POCOs.Task> tasks = TaskRepository.GetTasks().ToList();
            List<GetTaskResponse> response = Mapper.Map<List<GetTaskResponse>>(tasks);

            return System.Threading.Tasks.Task.FromResult(response);
        }
    }
}
