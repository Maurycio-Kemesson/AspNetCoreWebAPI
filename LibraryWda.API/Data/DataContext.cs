using LibraryWda.API.Models;
using Microsoft.EntityFrameworkCore;


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
        }
    }
}
