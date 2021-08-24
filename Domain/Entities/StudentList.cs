using System.Collections.Generic;

namespace Domain.Entities
{
    public class StudentList : IBaseEntity
    {
        public StudentList()
        {
            this.StudentsList = new HashSet<Student>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Student> StudentsList { get; set; }
    }
}
