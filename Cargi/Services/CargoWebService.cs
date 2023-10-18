using AutoMapper;
using Cargi.Services;
using Cargo.Configuration;
using Cargo.DTOs;
using Cargo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Cargo.Services
{
    public class CargoWebService : ICargoWebService
    {
        private HttpClient _client;
        private string _url;
        private string _cargoRequestUrl;
        private string _couriersUrl;
        private IMapper _mapper;
        public CargoWebService()
        {
            _client = new HttpClient();
            _url = @"https://localhost:5001/";
            _cargoRequestUrl = "CargoRequest";
            _couriersUrl = "Courier";
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperConfiguration());
            });

            _mapper = mapperConfig.CreateMapper();
        }

        public async Task<IEnumerable<Courier>> GetCouriers()
        {
            return await Get<Courier, CourierDto>(_couriersUrl);
        }

        public async Task<IEnumerable<CargoRequest>> GetCargoRequests()
        {
            return await Get<CargoRequest, CargoRequestDto>(_cargoRequestUrl); ;
        }

        public async Task CreateCargoRequest(Cargo.Models.Cargo cargo, Client sender, Client recipient, string adress)
        {
            var cargoDto = _mapper.Map<CargoDto>(cargo);
            var senderDto = _mapper.Map<ClientDto>(sender);
            var recipientDto = _mapper.Map<ClientDto>(recipient);

            var dto = new CargoRequestBody
            {
                Adress = adress,
                Cargo = cargoDto,
                Recipient = recipientDto,
                Sender = senderDto
            };
            await Post(dto, string.Empty);
        }

        public async Task DeleteCargoRequest(long id)
        {
            await _client.DeleteAsync($"{_url}{_cargoRequestUrl}/{id}");
        }

        public async Task UpdateCargoRequest(CargoRequest cargoRequest)
        {
            var cargoRequestDto = _mapper.Map<CargoRequestDto>(cargoRequest);
            await Post(cargoRequestDto, "update");
        }

        public async Task SubmittCargoRequest(long courierId, long cargoId, long cargoRequestId)
        {
            var submittCargoRequestDto = new SubmittCargoRequestDto
            {
                CargoId = cargoId,
                CargoRequestId = cargoRequestId,
                CourierId = courierId
            };
            await Post(submittCargoRequestDto, "submitt");
        }

        private async Task Post<T>(T dto, string path)
        {
            var httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{_url}{_cargoRequestUrl}/{path}"),
                Content = new StringContent(JsonConvert.SerializeObject(dto))
                {
                    Headers =
                    {
                        ContentType = MediaTypeHeaderValue.Parse("application/json"),
                    },
                }
            };
            await _client.SendAsync(httpRequest);
        }

        private async Task<IEnumerable<T>> Get<T, U>(string partUrl)
        {
            var response = await _client.GetAsync($"{_url}{partUrl}");
            var resultStr = await response.Content.ReadAsStringAsync();
            var cargoRequests = JsonConvert.DeserializeObject<IEnumerable<U>>(resultStr);
            var result = _mapper.Map<IEnumerable<T>>(cargoRequests);
            return result;
        }
    }
}
