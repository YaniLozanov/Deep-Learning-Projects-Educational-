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
    [Authorize(Roles = "Admin, User")]
    public class CarController : Controller
    {
        private readonly ICarService carService;
        private readonly UserManager<ApplicationUser> userManager;

        public CarController(ICarService carService, UserManager<ApplicationUser> userManager)
        {
            this.carService = carService;
            this.userManager = userManager;
        }

        
        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }
        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        public IActionResult Create(CarBindingModel carModel)
        {
          

            if (this.ModelState.IsValid)
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
               
                return this.View();
            }
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public IActionResult ShowCars()
        {
            var user = this.carService.GetUserByName(this.User.Identity.Name);

            var carsFromDb = this.carService.GetAllCarsForUserWithId(user.Id);

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

        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        public async Task<IActionResult> Remove(CarListingModel model)
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
                    ModelState.AddModelError(string.Empty, "Ivalid Password!");
                    return RedirectToAction("ShowCars", "Car");
                }
                else
                {
                    return RedirectToAction("ShowCars", "Car");
                }
            }
        }

        
        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var carFromDb = this.carService.GetCarById(id);

            var car = new EditCarBindingModel()
            {
                Brand = carFromDb.Brand,
                Model = carFromDb.Model,
                YearFrom = carFromDb.YearFrom,
                Number = carFromDb.Number
            };

            return this.View(car);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        public IActionResult Edit(EditCarBindingModel carModel)
        {

         

            if (this.ModelState.IsValid)
            {
                var car = this.carService.GetCarById(carModel.Id);


                car.Brand = carModel.Brand;
                car.Model = carModel.Model;
                car.YearFrom = carModel.YearFrom;



                if (car.Number != carModel.Number)
                {
                    if (!this.carService.IsThereSuchCarWithNumber(carModel.Number))
                    {
                        car.Number = carModel.Number;
                    }
                    else
                    {

                        ModelState.AddModelError("Number", "Invalid Number");
                        return this.View(carModel);
                    }
                }
              
              

                this.carService.EditCarData(car);

                return RedirectToAction("ShowCars", "Car");
            }
            else
            {

                ModelState.AddModelError("Number", "Invalid Number");
                return this.View(carModel);
            }


        }



    }
}