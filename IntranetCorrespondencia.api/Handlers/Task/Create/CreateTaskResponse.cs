namespace IntranetCorrespondencia.api.Handlers
{
    public class CreateTaskResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
