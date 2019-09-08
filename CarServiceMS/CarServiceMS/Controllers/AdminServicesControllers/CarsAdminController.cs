using CarServiceMS.Data;
using CarServiceMS.Data.Interfaces;
using CarServiceMS.Data.Models;
using CarServiceMS.Models.BindingModels;
using CarServiceMS.Models.CarModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CarServiceMS.Controllers.AdminServicesControllers
{
    [Authorize(Roles = "Admin")]
    public class CarsAdminController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IAdminService adminService;
        private readonly ICarService carService;

        public CarsAdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
                               RoleManager<IdentityRole> roleManager, IAdminService adminService,
                               ICarService carService)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.adminService = adminService;
            this.carService = carService;
        }

        public IActionResult ListAllCars()
        {
            var carsFromDb = this.adminService.GetAllCars();

            var carsBinding = carsFromDb.Select(car => new CarBindingModel()
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                YearFrom = car.YearFrom,
                Number = car.Number,
                RegistredOn = car.RegistredOn

            });


            var cars = new CarListingModel()
            {
                Cars = carsBinding
            };

            return this.View(cars);
        }

    }
}
