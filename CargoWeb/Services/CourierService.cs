using AutoMapper;
using CargoWeb.DTOs;
using CargoWeb.Models;
using CargoWeb.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoWeb.Services
{
    public class CourierService : ICourierService
    {
        private readonly IMapper _mapper;
        private readonly ICourierRepository _courierRepository;

        public CourierService(IMapper mapper, ICourierRepository courierRepository)
        {
            _mapper = mapper;
            _courierRepository = courierRepository;
        }

        public async Task<bool> CreateCourierAsync(CourierDto courierDto)
        {
            try
            {
                var courier = _mapper.Map<Courier>(courierDto);
                await _courierRepository.AddAsync(courier);
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public async Task<IEnumerable<Courier>> GetAllCouriersAsync()
        {
            try
            {
                var resultDb = await _courierRepository.GetAllAsync();
                var result = _mapper.Map<IEnumerable<Courier>>(resultDb);
                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}
