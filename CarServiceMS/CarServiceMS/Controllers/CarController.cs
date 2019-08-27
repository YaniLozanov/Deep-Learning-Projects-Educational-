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
    
        [HttpPost]   
        public  IActionResult Create(CarBindingModel carModel)
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

                return RedirectToAction("Index", "Home");
            }
            else
            {

                return this.View();
            }
        }

        public  IActionResult ShowCars()
        {
            var user = this.carService.GetUserByName(this.User.Identity.Name);

            var carsFromDb = this.carService.GetAllCars(user.Id);

            if (carsFromDb != null)
            {
                var cars = carsFromDb.Select(car => new CarBindingModel()
                {
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

        

    }
}
