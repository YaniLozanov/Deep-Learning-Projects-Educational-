using CarServiceMS.Data.Interfaces;
using CarServiceMS.Data.Models;
using CarServiceMS.Models.BindingModels;
using CarServiceMS.Models.CarModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceMS.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService carService;
        private readonly UserManager<ApplicationUser> userManager;

        public CarController(ICarService carService, UserManager<ApplicationUser> userManager)
        {
            this.carService = carService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(CarBindingModel carModel)
        {
            bool isCarAlreadyExists = this.carService.IsThereSuchCar(carModel.Number);

            if (this.ModelState.IsValid && (isCarAlreadyExists == false))
            {
                var car = new Car
                {
                    Brand = carModel.Brand,
                    Model = carModel.Model,
                    YearFrom = carModel.YearFrom,
                    RegistredOn = DateTime.Now,
                    Number = carModel.Number,
                    Owner = this.carService.GetUserByName(this.User.Identity.Name)
                };

                this.carService.AddCar(car);

                return RedirectToAction("ShowCars", "Car");
            }
            else
            {
                if (isCarAlreadyExists)
                {
                    ModelState.AddModelError("Number", "Invalid Number");
                    return this.View(carModel);
                }

                return this.View();
            }
        }

        [Authorize]
        public IActionResult ShowCars()
        {
            var user = this.carService.GetUserByName(this.User.Identity.Name);

            var carsFromDb = this.carService.GetAllCars(user.Id);

            if (carsFromDb != null)
            {
                var cars = carsFromDb.Select(car => new CarBindingModel()
                {
                    Id = car.Id,
                    Brand = car.Brand,
                    Model = car.Model,
                    Number = car.Number,
                    YearFrom = car.YearFrom

                });


                var carsBinding = new CarListingModel()
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

        public IActionResult Remove(int id)
        {
            var carRemoveModel = new CarRemoveModel() { Id = id };

            return this.View(carRemoveModel);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(CarRemoveModel model)
        {
            var carId = model.Id;
            var password = model.Password;
            var user = this.carService.GetUserByCarId(carId);
            var isPasswordValid = false;

            if (password != null)
            {
                isPasswordValid = await userManager.CheckPasswordAsync(user, password);

            }

            if (this.ModelState.IsValid && isPasswordValid)
            {
                this.carService.RemoveCar(model.Id);

                return RedirectToAction("ShowCars", "Car");
            }
            else
            {
                if (isPasswordValid == false)
                {
                    this.ModelState.AddModelError("Password", "Invalid Password!");
                    return RedirectToAction("Remove", "Car");
                }
                else
                {
                    return RedirectToAction("Remove", "Car");
                }
            }
        }

        public IActionResult Edit(int id)
        {
            var carFromDb = this.carService.GetCarById(id);

            var car = new CarBindingModel()
            {
                Brand = carFromDb.Brand,
                Model = carFromDb.Model,
                YearFrom = carFromDb.YearFrom,
                Number = carFromDb.Number
            };

            return this.View(car);
        }

        [HttpPost]
        public IActionResult Edit(CarBindingModel carModel)
        {

            bool isCarAlreadyExists = this.carService.IsThereSuchCar(carModel.Number);

            if (this.ModelState.IsValid && (isCarAlreadyExists == false))
            {
                var car = this.carService.GetCarById(carModel.Id);

                car.Brand = carModel.Brand;
                car.Model = carModel.Model;
                car.YearFrom = carModel.YearFrom;
                car.Number = carModel.Number;

                this.carService.EditCarData(car);

                return RedirectToAction("ShowCars", "Car");
            }
            else
            {

                if (isCarAlreadyExists)
                {
                    ModelState.AddModelError("Number", "Invalid Number");
                    return this.View(carModel);

                }

                return this.View(carModel);
            }


        }



    }
}