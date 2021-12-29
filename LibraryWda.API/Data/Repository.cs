﻿using LibraryWda.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWda.API.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
           return (_context.SaveChanges() > 0);
        }

        public Student[] GetAllStudents(bool includeBook = false)
        {
            IQueryable<Student> query = _context.Students;

            if (includeBook)
            {
                query = query.Include(s => s.BooksLoans)
                    .ThenInclude(sb => sb.Book)
                    .ThenInclude(b => b.PublishingCompany);
            }

            query = query.AsNoTracking().OrderBy(s => s.Id);

            return query.ToArray();
        }

        public Student[] GetAllStudentsByBookId(int bookId, bool includeBook = false)
        {
            IQueryable<Student> query = _context.Students;
            
            if (includeBook)
            {
                query = query.Include(s => s.BooksLoans)
                    .ThenInclude(sb => sb.Book)
                    .ThenInclude(b => b.PublishingCompany);
            }

            query = query.AsNoTracking()
                .OrderBy(s => s.Id)
                .Where(student => student.BooksLoans.Any(sb => sb.BookId == bookId));

            return query.ToArray();
        }

        public Student GetAllStudentByID(int studentId, bool includeBook = false)
        {
            IQueryable<Student> query = _context.Students;

            if(includeBook)
            {
                query = query.Include(s => s.BooksLoans)
                    .ThenInclude(sb => sb.Book)
                    .ThenInclude(b => b.PublishingCompany);
            }

            query = query.AsNoTracking()
                .OrderBy(s => s.Id)
                .Where(student => student.Id == studentId);

            return query.FirstOrDefault();
        }

        public Book[] GetAllBooks(bool includeStudent = false)
        {
            IQueryable<Book> query = _context.Books;

            if (includeStudent)
            {
                query = query.Include(b => b.BooksLoans);
            }

            query = query.AsNoTracking().OrderBy(s => s.Id);

            return query.ToArray();
        }

        public Book[] GetAllBooksByStudentId(int studentId, bool includeStudent = false)
        {
            IQueryable<Book> query = _context.Books;

            if (includeStudent)
            {
                query = query.Include(s => s.BooksLoans)
                    .ThenInclude(sb => sb.Book)
                    .ThenInclude(b => b.PublishingCompany);
            }

            query = query.AsNoTracking()
                .OrderBy(s => s.Id)
                .Where(student => student.BooksLoans.Any(sb => sb.BookId == studentId));

            return query.ToArray();
        }

        public Book GetAllBookByID(int bookId, bool includeStudent = false)
        {
            IQueryable<Book> query = _context.Books;

            if (includeStudent)
            {
                query = query.Include(s => s.BooksLoans)
                    .ThenInclude(sb => sb.Book)
                    .ThenInclude(b => b.PublishingCompany);
            }

            query = query.AsNoTracking()
                .OrderBy(s => s.Id)
                .Where(book => book.Id == bookId);

            return query.FirstOrDefault();
        }
    }
}