using LibraryWda.API.Data;
using LibraryWda.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryWda.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        
        public readonly IRepository _repo;

        public BookController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllBooks(true);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _repo.GetAllBookByID(id, false);
            if (book == null) return BadRequest("The book was not found.");

            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post(Book book)
        {
            _repo.Add(book);
            if (_repo.SaveChanges())
            {
                return Ok(book);
            }
            return BadRequest("Unregistered book!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Book book)
        {
            var boo = _repo.GetAllBookByID(id);
            if (boo == null) return BadRequest("The book was not found.");

            _repo.Update(book);
            if (_repo.SaveChanges())
            {
                return Ok(book);
            }
            return BadRequest("Book not updated!");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Book book)
        {
            var boo = _repo.GetAllBookByID(id);
            if (boo == null) return BadRequest("The book was not found.");

            _repo.Update(book);
            if (_repo.SaveChanges())
            {
                return Ok(book);
            }
            return BadRequest("Book not updated!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _repo.GetAllBookByID(id);
            if (book == null) return BadRequest("The book was not found.");

            _repo.Delete(book);
            if (_repo.SaveChanges())
            {
                return Ok("Deleted book");
            }
            return BadRequest("Undeleted book!");
        }
    }
}
