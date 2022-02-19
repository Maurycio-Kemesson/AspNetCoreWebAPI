using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWda.API.Dtos
{
    public class BookDto
    {
        /// <summary>
        /// Bank identifier and key.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Book cover image.
        /// </summary>
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
