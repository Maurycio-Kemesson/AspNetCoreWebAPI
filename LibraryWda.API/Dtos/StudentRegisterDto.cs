using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWda.API.Dtos
{
    public class StudentRegisterDto
    {
        public int Id { get; set; }
        public int Registration { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;
        public DateTime? ClosingDate { get; set; } = null;
        public bool Status { get; set; } = true;
        public string Address { get; set; }
    }
}
