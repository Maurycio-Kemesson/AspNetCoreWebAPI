using LibraryWda.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LibraryWda.API.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LibraryWda.API.Dtos;
using AutoMapper;


namespace LibraryWda.API.Controllers
{
    
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class StudentController : ControllerBase
    {
        
        public readonly IRepository _repo;

        public readonly IMapper _mapper;

        public StudentController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var students = _repo.GetAllStudents(true);
            
            return Ok(_mapper.Map<IEnumerable<StudentDto>>(students));
        }

        [HttpGet("getRegister")]
        public IActionResult GetRegister()
        {
            return Ok(new StudentRegisterDto());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _repo.GetAllStudentByID(id, false);
            if (student == null) return BadRequest("The student was not found.");

            var studentDto = _mapper.Map<StudentDto>(student);

            return Ok(studentDto);
        }

        [HttpPost]
        public IActionResult Post(StudentRegisterDto model)
        {

            var student = _mapper.Map<Student>(model);
            _repo.Add(student);
            if (_repo.SaveChanges())
            {
                return Created($"/api/student/{model.Id}", _mapper.Map<StudentDto>(student));
            }
            return BadRequest("Unregistered student!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, StudentRegisterDto model)
        {
            var student = _repo.GetAllStudentByID(id);
            if (student == null) return BadRequest("The student was not found.");

            _mapper.Map(model, student);

            _repo.Update(student);
            if (_repo.SaveChanges())
            {
                return Created($"/api/student/{model.Id}", _mapper.Map<StudentDto>(student));
            }
            return BadRequest("Student not updated!");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, StudentRegisterDto model)
        {
            var student = _repo.GetAllStudentByID(id);
            if (student == null) return BadRequest("The student was not found.");

            _mapper.Map(model, student);


            _repo.Update(student);
            if (_repo.SaveChanges())
            {
                return Created($"/api/student/{model.Id}", _mapper.Map<StudentDto>(student));
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
