using System;
using LibraryWda.API.Models;
namespace LibraryWda.API.V1.Dtos

{
    public class BookLoanDto
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Status { get; set; }
    }
}
