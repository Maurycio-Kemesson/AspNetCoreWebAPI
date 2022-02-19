using AutoMapper;
using LibraryWda.API.Data;
using LibraryWda.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWda.API.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryWda.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BookController : ControllerBase
    {
        
        public readonly IRepository _repo;

        public readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public BookController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        /// <summary>
        /// Responsible method for returning all my books.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var books = _repo.GetAllBooks(true);

            return Ok(_mapper.Map<IEnumerable<BookDto>>(books));
        }

        /// <summary>
        /// Method responsible for returning only a single BookDTO.
        /// </summary>
        /// <returns></returns>
        [HttpGet("getRegister")]
        public IActionResult GetRegister()
        {
            return Ok(new BookRegisterDto());
        }

        /// <summary>
        /// Method responsible for returns a book via ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _repo.GetAllBookByID(id, false);
            if (book == null) return BadRequest("The book was not found.");

            var bookDto = _mapper.Map<BookDto>(book);

            return Ok(bookDto);
        }

        /// <summary>
        /// Method responsible for registering a book.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(BookRegisterDto model)
        {
            var book = _mapper.Map<Book>(model);
            _repo.Add(book);
            if (_repo.SaveChanges())
            {
                return Created($"/api/book/{model.Id}", _mapper.Map<BookDto>(book));
            }
            return BadRequest("Unregistered book!");
        }

        /// <summary>
        /// Method responsible for updating a book record.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, BookRegisterDto model)
        {
            var book = _repo.GetAllBookByID(id);
            if (book == null) return BadRequest("The book was not found.");

            _mapper.Map(model, book);

            _repo.Update(book);
            if (_repo.SaveChanges())
            {
                return Created($"/api/book/{model.Id}", _mapper.Map<BookDto>(book));
            }
            return BadRequest("Book not updated!");
        }

        /// <summary>
        /// Method responsible for updating a book record.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BookRegisterDto model)
        {
            var book = _repo.GetAllBookByID(id);
            if (book == null) return BadRequest("The book was not found.");

            _mapper.Map(model, book);

            _repo.Update(book);
            if (_repo.SaveChanges())
            {
                return Created($"/api/book/{model.Id}", _mapper.Map<BookDto>(book));
            }
            return BadRequest("Book not updated!");
        }

        /// <summary>
        /// Method responsible for deleting a book record.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
