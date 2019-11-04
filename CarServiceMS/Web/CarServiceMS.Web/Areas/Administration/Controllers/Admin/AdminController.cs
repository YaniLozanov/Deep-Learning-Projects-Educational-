using System.Linq;
using CarServiceMS.Services.Interfaces.AdminInterfaces;
using CarServiceMS.Services.Interfaces.CarInterfaces;
using CarServiceMS.Services.Interfaces.UserInterfaces;
using CarServiceMS.Web.ViewModels.AdminViewModels.Statuses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceMS.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Administration")]
    public class AdminController : Controller
    {
        private readonly IAdminServices adminServices;
        private readonly IUserServices userServices;
        private readonly ICarServices carServices;


        public AdminController(IAdminServices adminServices, IUserServices userServices,
                               ICarServices carServices)
        {
            this.adminServices = adminServices;
            this.userServices = userServices;
            this.carServices = carServices;
        }

        [HttpGet]
        public IActionResult AdminPanel()
        {

            var totalUsersCount = this.userServices.GetAllUsers().Count();

            var adminsCount = this.adminServices.GetAllAdmins().Count();
            var bannedCount = this.adminServices.GetAllBannedUsers().Count();
            var ordinaryCount = this.adminServices.GetAllOrinaryUsers().Count();

            var usersStatus = new UserStatusViewModel()
            {
                Count = totalUsersCount,
                AdminsCount = adminsCount,
                BannedCount = bannedCount,
                OrdinaryCount = ordinaryCount
            };

            var carsCount = this.carServices.GetAllCars().Count();

            var carsStatus = new CarStatusViewModel()
            {
                Count = carsCount,
                InPrcessCount = carsCount, 
                ReadyCount = 0, // TODO
                WaitingCount = 0 // TODO
            };


            var statusesViewModel = new StatusesViewModel()
            {
                UsersStatus = usersStatus,
                CarsStatus = carsStatus
            };

            return this.View(statusesViewModel);
        }


    }
}