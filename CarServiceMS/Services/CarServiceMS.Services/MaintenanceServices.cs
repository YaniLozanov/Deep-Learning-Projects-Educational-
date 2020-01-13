using CarServiceMS.Service.Models;
using CarServiceMS.Services.Interfaces.CarInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarServiceMS.Services
{
    public class MaintenanceServices : IMaintenanceServices
    {
        public IEnumerable<MaintenanceServiceModel> GetAllMaintenancesForCarWithId(int carId)
        {
            throw new NotImplementedException();
        }

        public MaintenanceServiceModel GetMaintenanceById(int maintananceId)
        {
            throw new NotImplementedException();
        }
    }
}
