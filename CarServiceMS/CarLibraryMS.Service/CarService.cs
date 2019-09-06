using CarServiceMS.Data;
using CarServiceMS.Data.Interfaces;
using CarServiceMS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CarLibraryMS.Service
{
    public class CarService : ICarService

    {
        private readonly ApplicationDbContext context;

        public CarService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void AddCar(Car car)
        {
            this.context.Cars.Add(car);
            this.context.SaveChanges();
        }

        public IEnumerable<Car> GetAllCars(string userId)
        {
            return this.context.Cars
                .Include(car => car.Owner)
                .Where(car => car.Owner.Id == userId);
        }

        public Car GetCarById(int id)
        {
            var carFromDb = this.context.Cars
                .Include(car => car.Manipulations)
                .FirstOrDefault(car => car.Id == id);

            return carFromDb;
        }

        public ApplicationUser GetUserByName(string name)
        {
            return this.context.Users
                .Include(user => user.Cars).ThenInclude(car => car.Manipulations)
                .FirstOrDefault(user => user.UserName == name);
                
        }

        public void RemoveCar(int id)
        {
            this.context
                .Cars
                .Remove(this.context.Cars.FirstOrDefault(car => car.Id == id));

            this.context.SaveChanges();
        }

        public void EditCarData(Car car)
        {
            this.context.Cars.Update(car);

            this.context.SaveChanges();
        }

        public bool IsThereSuchCar(string number)
        {
            return this.context.Cars.Any(car => car.Number == number);
        }

        public ApplicationUser GetUserByCarId(int id)
        {
            return this.context.User
                .Include(user => user.Cars)
                .SingleOrDefault(user => user.Cars.Any(car => car.Id == id));
        }
    }
}
