﻿using CargoWeb.DTOs;
using CargoWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoWeb.Services
{
    public interface ICourierService
    {
        Task<bool> CreateCourierAsync(CourierDto courierDto);
        Task<IEnumerable<Courier>> GetAllCouriersAsync();

    }
}
