using AutoMapper;
using CarServiceMS.Data.Models;
using CarServiceMS.Service.Models;
using CarServiceMS.Services.Interfaces.CarInterfaces;
using CarServiceMS.Services.Interfaces.UserInterfaces;
using CarServiceMS.Web.InputModels;
using CarServiceMS.Web.InputModels.CarInputModels;
using CarServiceMS.Web.ViewModels.CarViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceMS.Web.Controllers.CarContorllers
{
    [Authorize(Roles = "Admin, User")]
    public class CarController : Controller
    {
        private readonly ICarServices carServices;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;
        private readonly IUserServices userServices;

        public CarController(ICarServices carService, UserManager<ApplicationUser> userManager,
                             IMapper mapper, IUserServices userServices)
        {
            this.carServices = carService;
            this.userManager = userManager;
            this.mapper = mapper;
            this.userServices = userServices;
        }

        [HttpGet]
        public IActionResult ListAllCars()
        {
            var carsFromDb = this.carServices.GetAllCars();

            var carListingViewModels = carsFromDb.Select(car => this.mapper.Map<CarListingViewModel>(car));


            var cars = new CarListWithViewModels()
            {
                Cars = carListingViewModels
            };

            return this.View(cars);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CarCreateInputModel carInputCreateInputModel)
        {

            if (this.ModelState.IsValid)
            {

                var carServiceModel = mapper.Map<CarServiceModel>(carInputCreateInputModel);
                carServiceModel.Owner = this.userServices.GetUserByName(this.User.Identity.Name);

                await this.carServices.AddCarAsync(carServiceModel);

                return RedirectToAction("ListCars", "Car");
            }
            else
            {
                return this.View();
            }
        }
        [HttpGet]
        public IActionResult ListCars()
        {
            var user = this.userServices.GetUserByName(this.User.Identity.Name);

            var carsFromDb = this.carServices.GetAllCarsForUserWithId(user.Id);

            if (carsFromDb != null)
            {
                var cars = carsFromDb.Select(car => this.mapper.Map<CarListingViewModel>(car));

                var carsBinding = new CarListWithViewModels()
                {
                    Cars = cars
                };

                return this.View(carsBinding);
            }
            else
            {
                return this.View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CarListWithViewModels model)
        {
            var carId = model.Id;
            var password = model.Password;
            var user = this.userServices.GetUserByCarId(carId);
            var isPasswordValid = false;

            if (password != null)
            {
                isPasswordValid = await userManager.CheckPasswordAsync(this.mapper.Map<ApplicationUser>(user), password);
            }

            if (this.ModelState.IsValid && isPasswordValid)
            {
              await  this.carServices.DeleteCarAsync(model.Id);

                return RedirectToAction("ListCars", "Car");
            }
            else
            {
                if (isPasswordValid == false)
                {
                    ModelState.AddModelError(string.Empty, "Ivalid Password!");
                    return this.RedirectToAction("ListCars", "Car");
                }
                else
                {
                    return RedirectToAction("ListCars", "Car");
                }
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var carFromDb = this.carServices.GetCarById(id);

            var carEditInputModel = this.mapper.Map<CarEditInputModel>(carFromDb);

            return this.View(carEditInputModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CarEditInputModel carModel)
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

                return RedirectToAction("ListCars", "Car");
            }
            else
            {

                ModelState.AddModelError("Number", "Invalid Number");
                return this.View(carModel);
            }


        }
    }
}
