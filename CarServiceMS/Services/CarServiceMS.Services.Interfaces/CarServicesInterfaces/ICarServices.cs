using CarServiceMS.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarServiceMS.Services.Interfaces.CarInterfaces
{
    public interface ICarServices
    {
        Task AddCarAsync(CarServiceModel carServiceModel);
        Task EditCarDataAsync(CarServiceModel carServiceModel);
        Task DeleteCarAsync(int carId);

        CarServiceModel GetCarById(int carId);
        IList<CarServiceModel> GetAllCars();

        IEnumerable<CarServiceModel> GetAllCarsForUserWithId(string userId);

        bool IsThereSuchCarWithNumber(string carNumber);
    }
}
