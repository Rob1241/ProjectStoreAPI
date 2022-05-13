using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProjectStore.Models;
using ProjectStore.Models.DTOs;
namespace ProjectStore
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, GetCustomerDTO>();
            CreateMap<CreateCustomerDTO, Customer>();
            CreateMap<Book, GetBookDTO>();
            CreateMap<CreateBookDTO, Book>();
        }
    }
}
