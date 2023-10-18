using AutoMapper;
using Cargo.DTOs;
using Cargo.Models;

namespace Cargo.Configuration
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Models.Cargo, CargoDto>().ReverseMap();
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<Courier, CourierDto>().ReverseMap();
            CreateMap<CargoRequest, CargoRequestDto>().ReverseMap();
        }
    }
}
