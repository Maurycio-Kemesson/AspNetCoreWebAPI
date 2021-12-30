using System;

namespace LibraryWda.API.Models
{
    public class BookLoan
    {
        public BookLoan() { }
        public BookLoan(int studentId, int bookId, DateTime loanDate, DateTime returnDate)
        {
            this.StudentId = studentId;
            this.BookId = bookId;
            this.LoanDate = loanDate;
            this.ReturnDate = returnDate;
        }

        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Status { get; set; }
    }
}
