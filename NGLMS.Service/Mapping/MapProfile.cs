using AutoMapper;
using NGLMS.Core.DTOs;
using NGLMS.Core.Models;

namespace NGLMS.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
