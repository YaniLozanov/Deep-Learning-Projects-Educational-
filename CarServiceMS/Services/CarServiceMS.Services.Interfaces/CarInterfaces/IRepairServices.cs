using CarServiceMS.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarServiceMS.Services.Interfaces.CarInterfaces
{
    public interface IRepairServices
    {
        RepairServiceModel GetRepairById(int repairId);
        IEnumerable<RepairServiceModel> GetAllRepairsForCarWithId(int carId);
    }
}
