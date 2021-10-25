namespace LibraryWda.API.Models
{
    public class BookLoan
    {
        public BookLoan() { }
        public BookLoan(int studentId, int bookId)
        {
            this.StudentId = studentId;
            this.BookId = bookId;
        }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
