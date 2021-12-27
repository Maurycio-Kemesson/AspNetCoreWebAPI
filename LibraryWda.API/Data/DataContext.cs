using LibraryWda.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LibraryWda.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookLoan> BookLoans { get; set; }
        public DbSet<PublishingCompany> PublishingCompanys { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BookLoan>()
                .HasKey(BL => new { BL.StudentId, BL.BookId });

            builder.Entity<User>()
                .HasData(new List<User>(){
                    new User(1, "Maurycio Kemesson","maurycio.kemesson@gmail.com", "Qwe123*"),
                   
                });

            builder.Entity<PublishingCompany>()
                .HasData(new List<PublishingCompany>() {
                    new PublishingCompany(1, "Interseca"),
                });

            builder.Entity<Book>()
                .HasData(new List<Book>{
                    new Book(1, "A culpa é das estrelas", 1),
                    new Book(2, "Quem é você alasca", 1),
                    new Book(3, "A dois passos de você", 1)
                });

            builder.Entity<Student>()
                .HasData(new List<Student>(){
                    new Student(1, "Maurycio", "Kemesson", "33225555", "Rua A"),
                    new Student(2, "Valdeli", "Nascimento", "3354288", "Rua A"),
                    new Student(3, "Rafael", "Araujo", "55668899", "Rua A"),
                    new Student(4, "Lucas", "Unifametro", "6565659", "Rua A"),
                    new Student(5, "Rhaun", "Junior", "565685415", "Rua A"),
                    new Student(6, "Caio", "Alvares", "456454545", "Rua A"),
                    new Student(7, "Pedro", "Lucas", "9874512", "Rua A")
                });

            builder.Entity<BookLoan>()
                .HasData(new List<BookLoan>() {
                    new BookLoan() {StudentId  = 1, BookId = 1 },
                    new BookLoan() {StudentId  = 2, BookId = 2 },
                    new BookLoan() {StudentId  = 3, BookId = 3 },       
                });
        }
    }
}
