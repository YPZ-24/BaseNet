using IntranetCorrespondencia.Entities.Interfaces;
using MediatR;
using AutoMapper;

namespace IntranetCorrespondencia.api.Handlers
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskRequest, CreateTaskResponse>
    {
        readonly ITaskRepository TaskRepository;
        readonly IMapper Mapper;

        public CreateTaskHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            TaskRepository = taskRepository;
            Mapper = mapper;
        }

        public Task<CreateTaskResponse> Handle(CreateTaskRequest request, CancellationToken cancellationToken)
        {
            Entities.POCOs.Task newTask = Mapper.Map<Entities.POCOs.Task>(request);
            newTask = TaskRepository.CreateTask(newTask);
            CreateTaskResponse response = Mapper.Map<CreateTaskResponse>(newTask);

            return System.Threading.Tasks.Task.FromResult(response);
        }
    }
}
