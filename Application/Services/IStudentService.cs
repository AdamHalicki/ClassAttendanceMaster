using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace Application.Services
{
    public interface IStudentService
    {
        Task<Result<Student>> GetStudent(int studentId);
        Task<Result<IEnumerable<Student>>> GetAllStudentsAsync();
        Task<Result<Student>> AddStudent(Student student);
        void UpdateStudent(Student student);
    }
}
