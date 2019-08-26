using CarServiceMS.Data.Models;
using System.Collections;
using System.Collections.Generic;

namespace CarServiceMS.Data.Interfaces
{
    public interface ICarService
    {
        Car GetCarById(int id);
        ApplicationUser GetUserById(string id);
        void AddCar(Car car);
        void RemoveCar(int id);
        void UpdateCarData(int id);


        IEnumerable<Car> GetAllCars(string userId);


    }
}
