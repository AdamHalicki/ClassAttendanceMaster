using System.Collections.Generic;

namespace Domain.Entities
{
    public class AttendanceList : IBaseEntity
    {
        public AttendanceList()
        {
            this.StudentsList = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string DateTime { get; set; }
        public virtual ICollection<Student> StudentsList { get; set; }
        public Lecturer Lecturer { get; set; }
        public Subject Subject { get; set; }
    }
}
