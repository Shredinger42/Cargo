using AutoMapper;
using CargoWeb.DTOs;
using CargoWeb.Models;
using CargoWeb.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoWeb.Services
{
    public class CargoRequestService : ICargoRequestService
    {
        private readonly ICourierCargoCargoRequestRepository _courierCargoCargoRequestRepository;
        private readonly ICargoRequestRepository _cargoRequestRepository;
        private readonly ICourierRepository _courierRepository;
        private readonly ICargoRepository _cargoRepository;
        private readonly IMapper _mapper;

        public CargoRequestService(
            ICourierCargoCargoRequestRepository courierCargoCargoRequestRepository,
            ICargoRequestRepository cargoRequestRepository,
            ICourierRepository courierRepository,
            ICargoRepository cargoRepository,
            IMapper mapper)
        {
            _courierCargoCargoRequestRepository = courierCargoCargoRequestRepository;
            _cargoRequestRepository = cargoRequestRepository;
            _courierRepository = courierRepository;
            _cargoRepository = cargoRepository;
            _mapper = mapper;
        }

        public async Task<bool> CreateCargoRequestAsync(CargoRequestBody body)
        {
            try
            {
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
                await _cargoRequestRepository.AddAsync(cargoRequest);
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public async Task<IEnumerable<CargoRequest>> GetAllCargoRequestsAsync()
        {
            try
            {
                var resultDb = await _cargoRequestRepository.GetAllAsync();
                var result = _mapper.Map<IEnumerable<CargoRequest>>(resultDb);
                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> UpdateCargoRequestAsync(CargoRequestDto cargoRequestDto)
        {
            try
            {
                var cargoRequest = _mapper.Map<CargoRequest>(cargoRequestDto);
                await _cargoRequestRepository.UpdateAsync(cargoRequest);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteCargoRequestAsync(long id)
        {
            try
            {
                await _cargoRequestRepository.DeleteByIdAsync(id);
                return true;

            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> SubmittCargoRequest(SubmittCargoRequestDto body)
        {
            try
            {
                var courierId = body.CourierId;
                var cargoRequestId = body.CargoRequestId;
                var cargoId = body.CargoId;
                
                return await _courierCargoCargoRequestRepository.Update(courierId, cargoId, cargoRequestId);
            }
            catch
            {
                return false;
            }
        }
    }
}
