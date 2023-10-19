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
    public class CargoRequestService : ICargoRequestService
    {
        private readonly ICourierCargoCargoRequestRepository _courierCargoCargoRequestRepository;
        private readonly ICargoRequestRepository _cargoRequestRepository;
        private readonly ILogger<CargoRequestService> _logger;
        private readonly IMapper _mapper;

        public CargoRequestService(
            ICourierCargoCargoRequestRepository courierCargoCargoRequestRepository,
            ICargoRequestRepository cargoRequestRepository,
            ILogger<CargoRequestService> logger,
            IMapper mapper)
        {
            _courierCargoCargoRequestRepository = courierCargoCargoRequestRepository;
            _cargoRequestRepository = cargoRequestRepository;
            _logger = logger;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<CargoRequest> CreateCargoRequestAsync(CargoRequestBody body)
        {
            try
            {
                _logger.LogInformation("Создаем новую заявку");
                var cargo = _mapper.Map<Cargo>(body.Cargo) ?? new Cargo();
                var sender = _mapper.Map<Client>(body.Sender) ?? new Client();
                var recipient = _mapper.Map<Client>(body.Recipient) ?? new Client();
                var cargoRequest = new CargoRequest
                {
                    Cargo = cargo,
                    Recipient = recipient,
                    Sender = sender,
                    State = CargoState.New,
                    Adress = body.Adress
                };
                var addedRequest = _mapper.Map<CargoRequest>(await _cargoRequestRepository.AddAsync(cargoRequest));
                if (addedRequest != null)
                {
                    _logger.LogInformation($"Новая заявка создана с id {addedRequest.Id}");
                }
                return addedRequest;
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Произошла ошибка при создании заявки");
                return null;
            }
        }
        /// <inheritdoc />
        public async Task<IEnumerable<CargoRequest>> GetAllCargoRequestsAsync()
        {
            try
            {
                _logger.LogInformation("Получаем все заявки");
                var resultDb = await _cargoRequestRepository.GetAllAsync();
                var result = _mapper.Map<IEnumerable<CargoRequest>>(resultDb);
                if (result != null)
                {
                    _logger.LogInformation("Были получены все заявки");
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Произошла ошибка при получении всех заявок");
                return null;
            }
        }
        /// <inheritdoc />
        public async Task<CargoRequest> UpdateCargoRequestAsync(CargoRequestDto cargoRequestDto)
        {
            try
            {
                _logger.LogInformation($"Обновляем заявку с id {cargoRequestDto.Id}");
                var cargoRequest = _mapper.Map<CargoRequest>(cargoRequestDto);
                var updatedRequest = _mapper.Map<CargoRequest>(await _cargoRequestRepository.UpdateAsync(cargoRequest));
                if (updatedRequest != null)
                {
                    _logger.LogInformation($"Заявка с id {cargoRequestDto.Id} была обновлена");
                }
                return updatedRequest;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Произошла ошибка при обновлении заявки с id {cargoRequestDto.Id}");
                return null;
            }
        }
        /// <inheritdoc />
        public async Task<CargoRequest> DeleteCargoRequestAsync(long id)
        {
            try
            {
                _logger.LogInformation($"Удаляем заявку с id {id}");
                var deletedRequest = _mapper.Map<CargoRequest>(await _cargoRequestRepository.DeleteByIdAsync(id));
                if (deletedRequest != null)
                {
                    _logger.LogInformation($"Заявка с id {id} была удалена");
                }
                return deletedRequest;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Произошла ошибка при удалении заявки с id {id}");
                return null;
            }
        }
        /// <inheritdoc />
        public async Task<CargoRequest> SubmittCargoRequest(SubmittCargoRequestDto body)
        {
            try
            {
                _logger.LogInformation($"Передаем на выполнение заявку с id {body.CargoRequestId} курьеру {body.CourierId} с грузом {body.CargoId}");
                var courierId = body.CourierId;
                var cargoRequestId = body.CargoRequestId;
                var cargoId = body.CargoId;
                
                var updatedCargoRequest = _mapper.Map<CargoRequest>(await _courierCargoCargoRequestRepository.Update(courierId, cargoId, cargoRequestId));
                if (updatedCargoRequest != null)
                {
                    _logger.LogInformation($"Заявка с id {updatedCargoRequest.Id} была передана на выполнение курьеру {updatedCargoRequest.Courier.Id}");
                }
                return updatedCargoRequest;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Произошла ошибка при передачи заявки с id {body.CargoRequestId} на выполнение");
                return null;
            }
        }
    }
}
