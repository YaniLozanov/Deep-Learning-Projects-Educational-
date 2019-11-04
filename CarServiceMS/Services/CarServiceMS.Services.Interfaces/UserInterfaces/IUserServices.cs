using CarServiceMS.Service.Models;
using System.Collections.Generic;

namespace CarServiceMS.Services.Interfaces.UserInterfaces
{
    public interface IUserServices
    {
        ApplicationUserServiceModel GetUserById(string id);
        ApplicationUserServiceModel GetUserByName(string name);
        ApplicationUserServiceModel GetUserByCarId(int carId);
        IList<ApplicationUserServiceModel> GetAllUsers();


    }
}
