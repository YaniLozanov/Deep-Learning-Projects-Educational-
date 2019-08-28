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
        public IActionResult Create ()
        {
            return this.View();
        }
    
        [Authorize]
        [HttpPost]   
        public  IActionResult Create(CarBindingModel carModel)
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

                return RedirectToAction("Index", "Home");
            }
            else
            {

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

            this.carService.RemoveCar(id);

            //return this.View("ShowCars");

            return RedirectToAction("ShowCars", "Car");
        }

        public IActionResult EditPage(int id)
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
        public IActionResult Edit(CarBindingModel  carModel)
        {
            var car = this.carService.GetCarById(carModel.Id);

            car.Brand = carModel.Brand;
            car.Model = carModel.Model;
            car.YearFrom = carModel.YearFrom;
            car.Number = carModel.Number;

            this.carService.EditCarData(car);

            return RedirectToAction("ShowCars", "Car");

        }



    }
}
