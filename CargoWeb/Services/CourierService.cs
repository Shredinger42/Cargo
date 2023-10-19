using AutoMapper;
using CargoWeb.DTOs;
using CargoWeb.Models;
using CargoWeb.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoWeb.Services
{
    public class CourierService : ICourierService
    {
        private readonly IMapper _mapper;
        private readonly ICourierRepository _courierRepository;
        private readonly ILogger<CourierService> _logger;

        public CourierService(IMapper mapper, ICourierRepository courierRepository, ILogger<CourierService> logger)
        {
            _mapper = mapper;
            _courierRepository = courierRepository;
            _logger = logger;
        }
        /// <inheritdoc />
        public async Task<Courier> CreateCourierAsync(CourierDto courierDto)
        {
            try
            {
                _logger.LogInformation("Создаем нового курьера");
                var courier = _mapper.Map<Courier>(courierDto);
                var newCourier = _mapper.Map<Courier>(await _courierRepository.AddAsync(courier));
                if (newCourier != null)
                {
                    _logger.LogInformation($"Новый курьер создан с id {newCourier.Id}");
                }
                return newCourier;
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Произошла ошибка при создании нового курьера");
                return null;
            }
        }
        /// <inheritdoc />
        public async Task<IEnumerable<Courier>> GetAllCouriersAsync()
        {
            try
            {
                _logger.LogInformation("Получаем всех курьеров");
                var resultDb = await _courierRepository.GetAllAsync();
                var result = _mapper.Map<IEnumerable<Courier>>(resultDb);
                if (result != null)
                {
                    _logger.LogInformation("Были получены все курьеры");
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Произошла ошибка при получении всех курьеров");
                return null;
            }
        }
    }
}
