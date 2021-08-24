using System;

namespace Domain.Entities
{
    public class Student : IBaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AlbumNumber { get; set; }
        public virtual StudentList StudentList { get; set; }
    }
}
