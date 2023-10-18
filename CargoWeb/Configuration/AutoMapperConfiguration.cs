using AutoMapper;
using CargoWeb.DbModels;
using CargoWeb.DTOs;
using CargoWeb.Models;

namespace CargoWeb.Configuration
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration() 
        {
            CreateMap<CargoDb, Cargo>().ReverseMap();
            CreateMap<ClientDb, Client>().ReverseMap();
            CreateMap<CourierDb, Courier>().ReverseMap();
            CreateMap<CargoRequestDb, CargoRequest>().ReverseMap();

            CreateMap<Cargo, CargoDto>().ReverseMap();
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<Courier, CourierDto>().ReverseMap();
            CreateMap<CargoRequest, CargoRequestDto>().ReverseMap();


        }
    }
}
