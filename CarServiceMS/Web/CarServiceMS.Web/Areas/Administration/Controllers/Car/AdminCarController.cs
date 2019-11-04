using AutoMapper;
using CarServiceMS.Data.Models;
using CarServiceMS.Services.Interfaces.AdminInterfaces;
using CarServiceMS.Services.Interfaces.CarInterfaces;
using CarServiceMS.Services.Interfaces.UserInterfaces;
using CarServiceMS.Web.InputModels.AdminInputModels.AdminCarInputModels;
using CarServiceMS.Web.ViewModels.AdminViewModels.AdminCarViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceMS.Web.Areas.Administration.Controllers.User
{
    [Authorize(Roles = "Admin")]
    [Area("Administration")]
    public class AdminCarController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;
        private readonly IAdminServices adminServices;
        private readonly IUserServices userServices;
        private readonly ICarServices carServices;

        public AdminCarController(UserManager<ApplicationUser> userManager, IMapper mapper,
                                    IAdminServices adminServices, IUserServices userServices,
                                    ICarServices carServices)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.adminServices = adminServices;
            this.userServices = userServices;
            this.carServices = carServices;
        }

        [HttpGet]
        public IActionResult ListAllCars()
        {
            var carsFromDb = this.carServices.GetAllCars();

            var adomCarListingViewModels = carsFromDb.Select(car => this.mapper.Map<AdminCarListingViewModel>(car));


            var cars = new AdminCarListWithViewModels()
            {
                Cars = adomCarListingViewModels
            };

            return this.View(cars);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCar(AdminCarListWithViewModels userCarsListingViewModel)
        {
            var carId = userCarsListingViewModel.Id;
            var password = userCarsListingViewModel.Password;
            var admin = await this.userManager.GetUserAsync(this.User);

            var isPasswordValid = false;

            if (password != null)
            {
                isPasswordValid = await userManager.CheckPasswordAsync(admin, password);

            }

            if (this.ModelState.IsValid && isPasswordValid)
            {
                await this.carServices.DeleteCarAsync(carId);

                return this.RedirectToAction($"ListAllCars", "AdminCar");
            }
            else
            {
                return this.RedirectToAction($"ListAllCars", "AdminCar");
            }

        }

        [HttpGet]
        public IActionResult EditCar(int id)
        {
            var carFromDb = this.carServices.GetCarById(id);

            var car = this.mapper.Map<AdminCarEditInputModel>(carFromDb);

            return this.View(car);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        public async Task<IActionResult> EditCar(AdminCarEditInputModel carModel)
        {
            if (this.ModelState.IsValid)
            {
                var car = this.carServices.GetCarById(carModel.Id);

                car.Brand = carModel.Brand;
                car.Model = carModel.Model;
                car.YearFrom = carModel.YearFrom;

                if (car.Number != carModel.Number)
                {
                    if (!this.carServices.IsThereSuchCarWithNumber(carModel.Number))
                    {
                        car.Number = carModel.Number;
                    }
                    else
                    {

                        ModelState.AddModelError("Number", "Invalid Number");
                        return this.View(carModel);
                    }
                }

                await this.carServices.EditCarDataAsync(car);

                return RedirectToAction("ListAllCars", "AdminCar");
            }
            else
            {

                ModelState.AddModelError("Number", "Invalid Number");
                return this.View(carModel);
            }
        }

    }
}
