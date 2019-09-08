using CarServiceMS.Data.Models;
using System.Collections.Generic;

namespace CarServiceMS.Data.Interfaces
{
    public interface IAdminService
    {
        IList<ApplicationUser> GetAllUsers();
        IList<ApplicationUser> GetAllAdmins();
        IList<Car> GetAllCars();
        

        void ChangeUserRole(ApplicationUser user, string role);
        void DeleteAdmin();
    }
}
