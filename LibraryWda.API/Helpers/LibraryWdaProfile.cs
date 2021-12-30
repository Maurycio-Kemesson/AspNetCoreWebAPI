﻿using AutoMapper;
using LibraryWda.API.Dtos;
using LibraryWda.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWda.API.Helpers
{
    public class LibraryWdaProfile : Profile
    {
        public LibraryWdaProfile()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Name} {src.Surname}")
                )
                .ForMember(
                dest => dest.Age,
                opt => opt.MapFrom(src => src.BirthDate.GetCurrentAge())
                );
            CreateMap<StudentDto, Student>();
            CreateMap<Student, StudentRegisterDto>().ReverseMap();

            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();
            CreateMap<Book, BookRegisterDto>().ReverseMap();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<User, UserRegisterDto>().ReverseMap();

            CreateMap<PublishingCompany, PublishingCompanyDto>();
            CreateMap<PublishingCompanyDto, PublishingCompany>();
            CreateMap<PublishingCompany, PublishingCompanyRegisterDto>().ReverseMap();

            CreateMap<BookLoan, BookLoanDto>();
            CreateMap<BookLoanDto, BookLoan>();
            CreateMap<BookLoan, BookLoanRegisterDto>().ReverseMap();
        }
    }
}
