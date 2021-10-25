using LibraryWda.API.Models;
using Microsoft.AspNetCore.Mvc;
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
        public List<Book> Books = new List<Book>()
        {
            new Book()
            {
                Id = 1,
                Title = "Maurycio Kemesson Nascimento Brito"
            },
            new Book()
            {
                Id = 2,
                Title = "Valdeli Araujo do nascimento"
            },
            new Book()
            {
                Id = 3,
                Title = "Antonio Rafael Jeday",
            }
        };

        public BookController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Books);
        }
    }
}
