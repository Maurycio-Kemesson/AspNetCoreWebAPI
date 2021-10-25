using LibraryWda.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryWda.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public List<Student> Students = new List<Student>()
        {
            new Student()
            {
                Id = 1,
                Name = "Maurycio",
                Surname = "Kemesson Nascimento Brito",
                Telephone = "(85) 98659-5978"
            },
            new Student()
            {
                Id = 2,
                Name = "Valdeli",
                Surname = "Araujo do Nascimento",
                Telephone = "(85) 98559-5977"
            },
            new Student()
            {
                Id = 3,
                Name = "Antonio",
                Surname = "Rafael Jeday",
                Telephone = "(85) 98859-5977"
            }
        };

        public StudentController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Students);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var student = Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return BadRequest("The student was not found.");

            return Ok(student);
        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string name, string surname)
        {
            var student = Students.FirstOrDefault(s => 
                s.Name.Contains(name) && s.Surname.Contains(surname)
            );
            if (student == null) return BadRequest("The student was not found.");

            return Ok(student);
        }

        [HttpPost]
        public IActionResult Post(Student student)
        {
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int Id, Student student)
        {
            return Ok(student);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int Id, Student student)
        {
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            return Ok();
        }


    }
}
