using System;


namespace LibraryWda.API.V1.Dtos
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
