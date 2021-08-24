using CSharpFunctionalExtensions;
using Domain.Entities;
using Domain.Repositiories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Implementations
{
    public class StudentService: IStudentService
    {
        private readonly IRepository<Student> repository;

        public StudentService(IRepository<Student> repository)
        {
            this.repository = repository;
        }

        public async Task<Result<Student>> AddStudent(Student student)
        {
            await repository.AddAsync(student);
            await repository.SaveChangesAsync();

            return Result.Success(student);
        }

        public async Task<Result<Student>> GetStudent(int studentId)
        {
            var student = await repository.GetByIdAsync(studentId);

            return Result.Success(student);
        }

        public async Task<Result<IEnumerable<Student>>> GetAllStudentsAsync()
        {
            var students = await repository.GetAllAsync();

            return Result.Success(students);
        }

        public void UpdateStudent(Student student)
        {
            repository.Update(student);
            repository.SaveChanges();
        }
    }
}
