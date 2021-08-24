using Domain.Entities;
using Domain.Repositiories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactApp.Initializers
{
    public class StudentInitializer
    {
        private readonly IRepository<Student> studentRepository;

        public StudentInitializer(IRepository<Student> studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public async Task SeedStudentsAsync()
        {
            var studentsCount = (await studentRepository.GetAllIdsAsync()).Count();
            var diff = 0;

            while (studentsCount + diff <= 10)
            {
                var student = new Student
                {
                    FirstName = $"SImie_{diff}",
                    LastName = $"SNazwisko_{diff}",
                    AlbumNumber = diff
                };

                await studentRepository.AddAsync(student);
                diff++;
            }

            await studentRepository.SaveChangesAsync();
        }
    }
}
