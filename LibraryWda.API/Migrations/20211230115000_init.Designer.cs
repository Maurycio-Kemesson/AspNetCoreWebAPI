// <auto-generated />
using System;
using LibraryWda.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryWda.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211230115000_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("LibraryWda.API.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .HasColumnType("TEXT");

                    b.Property<string>("Img")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("PublishingCompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantities")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PublishingCompanyId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "John Green",
                            PublicationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublishingCompanyId = 1,
                            Quantities = 1,
                            Title = "A culpa é das estrelas"
                        },
                        new
                        {
                            Id = 2,
                            Author = "John Green",
                            PublicationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublishingCompanyId = 1,
                            Quantities = 1,
                            Title = "Quem é você Alasca?"
                        },
                        new
                        {
                            Id = 3,
                            Author = "John Green",
                            PublicationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublishingCompanyId = 1,
                            Quantities = 1,
                            Title = "Will & Will"
                        });
                });

            modelBuilder.Entity("LibraryWda.API.Models.BookLoan", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LoanDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.HasKey("StudentId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("BookLoans");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            BookId = 1,
                            LoanDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReturnDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            StudentId = 2,
                            BookId = 2,
                            LoanDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReturnDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            StudentId = 3,
                            BookId = 3,
                            LoanDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReturnDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("LibraryWda.API.Models.PublishingCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Initials")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PublishingCompanys");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Interseca"
                        });
                });

            modelBuilder.Entity("LibraryWda.API.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ClosingDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Registration")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telephone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Rua A",
                            BirthDate = new DateTime(2001, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EnrollmentDate = new DateTime(2021, 12, 30, 8, 50, 0, 256, DateTimeKind.Local).AddTicks(1319),
                            Name = "Maurycio",
                            Registration = 20221,
                            Status = true,
                            Surname = "Kemesson",
                            Telephone = "33225555"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Rua A",
                            BirthDate = new DateTime(1997, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EnrollmentDate = new DateTime(2021, 12, 30, 8, 50, 0, 257, DateTimeKind.Local).AddTicks(4368),
                            Name = "Valdeli",
                            Registration = 20222,
                            Status = true,
                            Surname = "Nascimento",
                            Telephone = "3354288"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Rua A",
                            BirthDate = new DateTime(1985, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EnrollmentDate = new DateTime(2021, 12, 30, 8, 50, 0, 257, DateTimeKind.Local).AddTicks(4460),
                            Name = "Rafael",
                            Registration = 20223,
                            Status = true,
                            Surname = "Araujo",
                            Telephone = "55668899"
                        });
                });

            modelBuilder.Entity("LibraryWda.API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "maurycio.kemesson@gmail.com",
                            Name = "Maurycio Kemesson",
                            Password = "Qwe123*"
                        });
                });

            modelBuilder.Entity("LibraryWda.API.Models.Book", b =>
                {
                    b.HasOne("LibraryWda.API.Models.PublishingCompany", "PublishingCompany")
                        .WithMany()
                        .HasForeignKey("PublishingCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LibraryWda.API.Models.BookLoan", b =>
                {
                    b.HasOne("LibraryWda.API.Models.Book", "Book")
                        .WithMany("BooksLoans")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryWda.API.Models.Student", "Student")
                        .WithMany("BooksLoans")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
