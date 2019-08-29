using CarServiceMS.Data.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarServiceMS.Data.Interfaces
{
    public interface ICarService
    {
        Car GetCarById(int id);
        ApplicationUser GetUserByName(string name);
        ApplicationUser GetUserByCarId(int id);
        void AddCar(Car car);
        void RemoveCar(int id);
        void EditCarData(Car car);
        bool IsThereSuchCar(string number);

        IEnumerable<Car> GetAllCars(string userId);


    }
}
