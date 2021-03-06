using System;
using System.Collections.Generic;

namespace LibraryWda.API.Models
{
    public class Book
    {

        public Book() { }
        public Book(int id, string title, string author, string gender,int quantities, int publishingCompanyId)
        {
            this.Id = id;
            this.Title = title;
            this.Author = author;
            this.Gender = Gender;
            this.Quantities = quantities;
            this.PublishingCompanyId = publishingCompanyId;
        }
        public int Id { get; set; }
        public string Img { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public int PublishingCompanyId { get; set; }
        public int Quantities { get; set; }
        public DateTime PublicationDate { get; set; }
        public PublishingCompany PublishingCompany { get; set; }
        public IEnumerable<BookLoan> BooksLoans { get; set; }

    }
}
