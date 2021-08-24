
namespace Domain.Entities
{
    public class Subject : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SubjectType { get; set; }
    }
}
