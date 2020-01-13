using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarServiceMS.Data;
using CarServiceMS.Data.Models;
using CarServiceMS.Service.Models;
using CarServiceMS.Services.Interfaces.CarInterfaces;
using Microsoft.EntityFrameworkCore;

namespace CarServiceMS.Services
{
    public class CarServices : ICarServices
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CarServices(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task AddCarAsync(CarServiceModel carServiceModel)
        {
            if (carServiceModel != null)
            {
                Car car = this.mapper.Map<Car>(carServiceModel);

                this.context.Cars.Add(car);
                await this.context.SaveChangesAsync();
            }
        }
        public async Task EditCarDataAsync(CarServiceModel carServiceModel)
        {
            if (carServiceModel != null)
            {
                var carFromDb = this.context.Cars.FirstOrDefault(c => c.Id == carServiceModel.Id);


                this.context.Cars.Update(carFromDb);

                carFromDb.Model = carServiceModel.Model;
                carFromDb.Brand = carServiceModel.Brand;
                carFromDb.YearFrom = carServiceModel.YearFrom;
                carFromDb.Number = carServiceModel.Number;

                await this.context.SaveChangesAsync();
            }
        }
        public async Task DeleteCarAsync(int carId)
        {
            Car car = this.context.Cars.FirstOrDefault(c => c.Id == carId);

            this.context.Cars.Remove(car);
            await this.context.SaveChangesAsync();
        }

        public IList<CarServiceModel> GetAllCars()
        {
            var carsFromDb = this.context.Cars
              .Include(car => car.Owner)
              .ThenInclude(owner => owner.Cars)
              .ToList();

            var carServiceModels = carsFromDb.Select(car => this.mapper.Map<CarServiceModel>(car)).ToList();

            return carServiceModels;
        }
        public CarServiceModel GetCarById(int carId)
        {

            var carFromDb = this.context.Cars
            .FirstOrDefault(car => car.Id == carId);

            var carServiceModel = this.mapper.Map<CarServiceModel>(carFromDb);

            return carServiceModel;

        }
        public bool IsThereSuchCarWithNumber(string carNumber)
        {
            return this.context.Cars.Any(car => car.Number == carNumber);
        }
        public IEnumerable<CarServiceModel> GetAllCarsForUserWithId(string userId)
        {

            var carsFromDb = this.context.Cars
            .Include(car => car.Owner)
            .Where(car => car.Owner.Id == userId);

            var carServiceModels = carsFromDb.Select(car => this.mapper.Map<CarServiceModel>(car));

            return carServiceModels;

        }

    }
}
