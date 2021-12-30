using System;
using System.Collections.Generic;

namespace LibraryWda.API.Models
{
    public class Student
    {
        public Student() { }
        public Student(int id, int registration, string name, string surname, String telephone, string address, DateTime birthdate)
        {
            this.Id = id;
            this.Registration = registration;
            this.Name = name;
            this.Surname = surname;
            this.Telephone = telephone;
            this.Address = address;
            this.BirthDate = birthdate;

        }
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
        public IEnumerable<BookLoan> BooksLoans { get; set; }
    }
}
