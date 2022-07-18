﻿using LibraryWda.API.Helpers;
using LibraryWda.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWda.API.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        //Student
        Student[] GetAllStudents(bool includeBook = false);
        Student[] GetAllStudentsByBookId(int bookId, bool includeBook = false);
        Student GetAllStudentByID(int studentId, bool includeBook = false);

        //Book
        Task<PageList<Book>> GetAllBooksAsync(PageParams pageParams, bool includeStudent = false);
        Book[] GetAllBooks(bool includeStudent = false);
        Book[] GetAllBooksByStudentId(int studentId, bool includeStudent = false);
        Book GetAllBookByID(int bookId, bool includeStudent = false);

        //User
        User[] GetAllUsers();
        User GetAllUserByID(int bookId);

        //Publishing Company
        PublishingCompany[] GetAllPublishingsCompanys();
        PublishingCompany GetAllPublishingCompanyByID(int bookId);

        //Book Loan
        BookLoan[] GetAllBooksLoans();
        BookLoan GetAllBookLoanByID(int bookId);









    }
}
