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
        private readonly DataContext _context;

        public BookController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Books);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var book = _context.Books.FirstOrDefault(s => s.Id == id);
            if (book == null) return BadRequest("The book was not found.");

            return Ok(book);
        }

        [HttpGet("ByTitle")]
        public IActionResult GetByTitle(string title)
        {
            var book = _context.Books.FirstOrDefault(s =>
                s.Title.Contains(title)
            );
            if (book == null) return BadRequest("The book was not found.");

            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post(Book book)
        {
            _context.Add(book);
            _context.SaveChanges();
            return Ok(book);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Book book)
        {
            var boo = _context.Books.AsNoTracking().FirstOrDefault(s => s.Id == id);
            if (boo == null) return BadRequest("The book was not found.");

            _context.Update(book);
            _context.SaveChanges();
            return Ok(book);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Book book)
        {
            var boo = _context.Students.AsNoTracking().FirstOrDefault(s => s.Id == id);
            if (boo == null) return BadRequest("The book was not found.");

            _context.Update(book);
            _context.SaveChanges();
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.FirstOrDefault(s => s.Id == id);
            if (book == null) return BadRequest("The book was not found.");

            _context.Remove(book);
            _context.SaveChanges();
            return Ok();
        }
    }
}
