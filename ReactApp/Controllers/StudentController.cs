using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using ReactApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReactApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> Get()
        {
            var studentResult = await this.studentService.GetAllStudentsAsync();

            return Ok(studentResult.Value.ToList());
        }

        [HttpGet("{studentId}")]
        public async Task<ActionResult> Get(int studentId)
        {
            var studentResult = await this.studentService.GetStudent(studentId);

            return Ok(studentResult.Value);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] StudentDto student)
        {
            Student studentObject = new Student()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                AlbumNumber = student.AlbumNumber
            };

            var result = await studentService.AddStudent(studentObject);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return BadRequest();
        }

        [HttpPut("{studentId}")]
        public ActionResult Put(int studentId, [FromBody] StudentDto student)
        {
            Student studentObject = new Student()
            {
                Id = studentId,
                FirstName = student.FirstName,
                LastName = student.LastName,
                AlbumNumber = student.AlbumNumber
            };

            studentService.UpdateStudent(studentObject);

            return Ok();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
