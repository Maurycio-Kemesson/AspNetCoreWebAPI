using LibraryWda.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LibraryWda.API.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryWda.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        
        public readonly IRepository _repo;

        public StudentController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllStudents(true);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _repo.GetAllStudentByID(id, false);
            if (student == null) return BadRequest("The student was not found.");

            return Ok(student);
        }

        [HttpPost]
        public IActionResult Post(Student student)
        {
            _repo.Add(student);
            if (_repo.SaveChanges())
            {
                return Ok(student);
            }
            return BadRequest("Unregistered student!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Student student)
        {
            var stud = _repo.GetAllStudentByID(id);
            if (stud == null) return BadRequest("The student was not found.");

            _repo.Update(stud);
            if (_repo.SaveChanges())
            {
                return Ok(stud);
            }
            return BadRequest("Student not updated!");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Student student)
        {
            var stud = _repo.GetAllStudentByID(id);
            if (stud == null) return BadRequest("The student was not found.");

            _repo.Update(stud);
            if (_repo.SaveChanges())
            {
                return Ok(stud);
            }
            return BadRequest("Student not updated!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _repo.GetAllStudentByID(id);
            if (student == null) return BadRequest("The student was not found.");

            _repo.Delete(student);
            if (_repo.SaveChanges())
            {
                return Ok("Deleted student");
            }
            return BadRequest("Undeleted student!");
        }


    }
}
