using AutoMapper;
using CleanArchitecture_DesignPatterns.Application.Dtos.BookDtos;
using CleanArchitecture_DesignPatterns.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture_DesignPatterns.Application.Profiles.Book_RelatedProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, GetBookDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name));
        }
    }
}
