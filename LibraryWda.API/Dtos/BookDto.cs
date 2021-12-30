using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWda.API.Dtos
{
    public class BookDto
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
    }
}
