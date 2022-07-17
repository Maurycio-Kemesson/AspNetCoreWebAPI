﻿using System;


namespace LibraryWda.API.V1.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }
        public int Registration { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public int Age { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public bool Status { get; set; } = true;
        public string Address { get; set; }
    }
}
