using IntranetCorrespondencia.Entities.Interfaces;

namespace IntranetCorrespondencia.Entities.POCOs.Base
{
    public class EntityBase : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
