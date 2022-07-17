using AutoMapper;
using LibraryWda.API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LibraryWda.API.V1.Dtos;
using LibraryWda.API.Models;


namespace LibraryWda.API.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BookLoanController : ControllerBase
    {
        public readonly IRepository _repo;

        public readonly IMapper _mapper;

        public BookLoanController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var booksloans = _repo.GetAllBooksLoans();

            return Ok(_mapper.Map<IEnumerable<BookLoanDto>>(booksloans));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var bookloan = _repo.GetAllBookLoanByID(id);
            if (bookloan == null) return BadRequest("The book loan was not found.");

            var booklonDto = _mapper.Map<BookLoanDto>(bookloan);

            return Ok(booklonDto);
        }

        [HttpGet("getRegister")]
        public IActionResult GetRegister()
        {
            return Ok(new BookLoanRegisterDto());
        }

        [HttpPost]
        public IActionResult Post(BookLoanRegisterDto model)
        {

            var bookloan = _mapper.Map<BookLoan>(model);
            _repo.Add(bookloan);
            if (_repo.SaveChanges())
            {
                return Created($"/api/bookloan/{model.StudentId}", _mapper.Map<BookLoanDto>(bookloan));
            }
            return BadRequest("Unregistered book loan!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, BookLoanRegisterDto model)
        {
            var bookloan = _repo.GetAllBookLoanByID(id);
            if (bookloan == null) return BadRequest("The book loan was not found.");

            _mapper.Map(model, bookloan);

            _repo.Update(bookloan);
            if (_repo.SaveChanges())
            {
                return Created($"/api/bookloan/{model.StudentId}", _mapper.Map<BookLoanDto>(bookloan));
            }
            return BadRequest("Book loan not updated!");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BookLoanRegisterDto model)
        {
            var bookloan = _repo.GetAllBookLoanByID(id);
            if (bookloan == null) return BadRequest("The book loan was not found.");

            _mapper.Map(model, bookloan);


            _repo.Update(bookloan);
            if (_repo.SaveChanges())
            {
                return Created($"/api/bookloan/{model.StudentId}", _mapper.Map<BookLoanDto>(bookloan));
            }
            return BadRequest("Book loan not updated!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var bookloan = _repo.GetAllBookLoanByID(id);
            if (bookloan == null) return BadRequest("The book loan was not found.");

            _repo.Delete(bookloan);
            if (_repo.SaveChanges())
            {
                return Ok("Deleted book loan");
            }
            return BadRequest("Undeleted book loan!");
        }
    }
}
