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
        private readonly DataContext _context;

        public StudentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Students);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return BadRequest("The student was not found.");

            return Ok(student);
        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string name, string surname)
        {
            var student = _context.Students.FirstOrDefault(s => 
                s.Name.Contains(name) && s.Surname.Contains(surname)
            );
            if (student == null) return BadRequest("The student was not found.");

            return Ok(student);
        }

        [HttpPost]
        public IActionResult Post(Student student)
        {
            _context.Add(student);
            _context.SaveChanges();
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Student student)
        {
            var stud = _context.Students.AsNoTracking().FirstOrDefault(s => s.Id == id);
            if (stud == null) return BadRequest("The student was not found.");

            _context.Update(student);
            _context.SaveChanges();
            return Ok(student);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Student student)
        {
            var stud = _context.Students.AsNoTracking().FirstOrDefault(s => s.Id == id);
            if (stud == null) return BadRequest("The student was not found.");

            _context.Update(student);
            _context.SaveChanges();
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return BadRequest("The student was not found.");

            _context.Remove(student);
            _context.SaveChanges();
            return Ok();
        }


    }
}
