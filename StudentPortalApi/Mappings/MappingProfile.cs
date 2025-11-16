using AutoMapper;
using StudentPortalApi.DTOs;
using StudentPortalApi.Models;

namespace StudentPortalApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Map Student <-> StudentDTO
            CreateMap<Student, StudentDTO>().ReverseMap();
            // Map Address <-> AddressDTO
            CreateMap<Address, AddressDTO>().ReverseMap();
        }
    }
}
