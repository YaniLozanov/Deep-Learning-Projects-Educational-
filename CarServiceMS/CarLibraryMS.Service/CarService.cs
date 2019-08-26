﻿using CarServiceMS.Data;
using CarServiceMS.Data.Interfaces;
using CarServiceMS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
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
            return this.context.Cars
                .Include(car => car.Manipulations)
                .FirstOrDefault(car => car.Id == id);
        }

        public ApplicationUser GetUserById(string id)
        {
            return this.context.Users
                .Include(user => user.Cars).ThenInclude(car => car.Manipulations)
                .FirstOrDefault(user => user.Id == id);
                
        }

        public void RemoveCar(int id)
        {
            this.context
                .Cars
                .Remove(this.context.Cars.FirstOrDefault(car => car.Id == id));
            this.context.SaveChanges();
        }

        public void UpdateCarData(int id)
        {
            throw new NotImplementedException();
        }
    }
}
