using LibraryWda.API.Models;
using System;
using System.Collections.Generic;

namespace LibraryWda.API.V1.Dtos
{
    public class BookRegisterDto
    {
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
