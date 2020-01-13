using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CarServiceMS.Data;
using CarServiceMS.Service.Models;
using CarServiceMS.Services.Interfaces.CarInterfaces;
using Microsoft.EntityFrameworkCore;

namespace CarServiceMS.Services
{
    public class RepairServices : IRepairServices
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;

        public RepairServices(IMapper mapper, ApplicationDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public RepairServiceModel GetRepairById(int repairId)
        {
            var repairsFromDb = this.context.Repairs
            .Include(repair => repair.Car).ThenInclude(car => car.Owner)
            .Include(repair => repair.Parts)
            .Include(repair => repair.CompletedActions)
            .Include(repair => repair.ReportedDefects)
            .FirstOrDefault(repair => repair.Id == repairId);

            var repairServiceModel = this.mapper.Map<RepairServiceModel>(repairsFromDb);

            return repairServiceModel;

        }
        public IEnumerable<RepairServiceModel> GetAllRepairsForCarWithId(int carId)
        {
            var repairsFromDb = this.context.Repairs
                .Include(repair => repair.Parts)
                .Include(repair => repair.CompletedActions)
                .Include(repair => repair.ReportedDefects)
                .Where(repair => repair.Car.Id == carId);


            var repairServiceModels = repairsFromDb.Select(repair => this.mapper.Map<RepairServiceModel>(repair));

            return repairServiceModels;
        }


    }
}
