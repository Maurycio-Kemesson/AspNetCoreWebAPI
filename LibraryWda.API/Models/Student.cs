using System;
using System.Collections.Generic;

namespace LibraryWda.API.Models
{
    public class Student
    {
        public Student() { }
        public Student(int id, string name, string surname, String telephone, string address)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Telephone = telephone;
            this.Address = address;

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public IEnumerable<BookLoan> BooksLoans { get; set; }
    }
}
