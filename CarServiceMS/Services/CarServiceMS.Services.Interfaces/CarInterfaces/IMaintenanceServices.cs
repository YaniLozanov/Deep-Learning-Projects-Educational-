using CarServiceMS.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarServiceMS.Services.Interfaces.CarInterfaces
{
    public interface IMaintenanceServices
    {
        MaintenanceServiceModel GetMaintenanceById(int maintananceId);
        IEnumerable<MaintenanceServiceModel> GetAllMaintenancesForCarWithId(int carId);


    }
}
