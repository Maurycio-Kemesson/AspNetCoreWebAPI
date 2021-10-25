using System.Collections.Generic;

namespace LibraryWda.API.Models
{
    public class Book
    {

        public Book() { }
        public Book(int id, string title, int publishingCompanyId)
        {
            this.Id = id;
            this.Title = title;
            this.PublishingCompanyId = publishingCompanyId;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public int PublishingCompanyId { get; set; }
        public PublishingCompany PublishingCompany { get; set; }
        public IEnumerable<BookLoan> BooksLoans { get; set; }

    }
}
