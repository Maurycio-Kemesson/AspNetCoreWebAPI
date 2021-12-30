using AutoMapper;
using LibraryWda.API.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWda.API.Dtos;
using LibraryWda.API.Models;

namespace LibraryWda.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IRepository _repo;

        public readonly IMapper _mapper;

        public UserController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _repo.GetAllUsers();

            return Ok(_mapper.Map<IEnumerable<UserDto>>(users));
        }

        [HttpGet("getRegister")]
        public IActionResult GetRegister()
        {
            return Ok(new UserRegisterDto());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _repo.GetAllUserByID(id);
            if (user == null) return BadRequest("The user was not found.");

            var userDto = _mapper.Map<UserDto>(user);

            return Ok(userDto);
        }

        [HttpPost]
        public IActionResult Post(UserRegisterDto model)
        {

            var user = _mapper.Map<User>(model);
            _repo.Add(user);
            if (_repo.SaveChanges())
            {
                return Created($"/api/book/{model.Id}", _mapper.Map<UserDto>(user));
            }
            return BadRequest("Unregistered user!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UserRegisterDto model)
        {
            var user = _repo.GetAllUserByID(id);
            if (user == null) return BadRequest("The user was not found.");

            _mapper.Map(model, user);

            _repo.Update(user);
            if (_repo.SaveChanges())
            {
                return Created($"/api/user/{model.Id}", _mapper.Map<UserDto>(user));
            }
            return BadRequest("User not updated!");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, UserRegisterDto model)
        {
            var user = _repo.GetAllUserByID(id);
            if (user == null) return BadRequest("The user was not found.");

            _mapper.Map(model, user);


            _repo.Update(user);
            if (_repo.SaveChanges())
            {
                return Created($"/api/user/{model.Id}", _mapper.Map<UserDto>(user));
            }
            return BadRequest("User not updated!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _repo.GetAllUserByID(id);
            if (user == null) return BadRequest("The user was not found.");

            _repo.Delete(user);
            if (_repo.SaveChanges())
            {
                return Ok("Deleted user");
            }
            return BadRequest("Undeleted user!");
        }
    }
}
