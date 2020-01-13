using AutoMapper;
using CarServiceMS.Services.Interfaces.CarInterfaces;
using CarServiceMS.Web.ViewModels.CarServicesViewModels.MaintananceViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CarServiceMS.Web.Controllers.CarServicesControllers
{
    public class MaintenanceController : Controller
    {
        private readonly IMapper mapper;
        private readonly IMaintenanceServices maintenanceServices;

        public MaintenanceController(IMapper mapper, IMaintenanceServices maintenanceServices)
        {
            this.mapper = mapper;
            this.maintenanceServices = maintenanceServices;
        }

        [HttpGet]
        public IActionResult ListAllMaintenances(int carId)
        {
            var maintenanceServiceModels = this.maintenanceServices.GetAllMaintenancesForCarWithId(carId)
                .OrderBy(maintenanceServiceModel => maintenanceServiceModel.Date)
                .ToList();


            var maintananceListingViewModels = maintenanceServiceModels
                .Select(maintananceServiceModel => this.mapper.Map<MaintananceListingViewModel>(maintananceServiceModel)).ToList();

            var maintanaceListWithListingViewModels = new MaintananceListWithListingViewModels()
            {
                Maintanances = maintananceListingViewModels
            };

            return this.View(maintanaceListWithListingViewModels);
        }
        [HttpGet]
        public IActionResult ShowMaintenanceDetails(int repairId)
        {
            var maintananceServiceModel = this.maintenanceServices.GetMaintenanceById(repairId);
            var maintananceViewModel = this.mapper.Map<MaintananceDetailsViewModel>(maintananceServiceModel);

            return this.View(maintananceViewModel);
        }
    }
}
