using CarServiceMS.Data.Models;
using System.Collections.Generic;

namespace CarServiceMS.Data.Interfaces
{
    public interface IAdminService
    {
        IList<ApplicationUser> GetAllUsers();
        IList<ApplicationUser> GetAllAdmins();
        IList<Car> GetAllCars();
        ApplicationUser GetUserById(string id);


        void ChangeUserRole(ApplicationUser user, string role);
        void DeleteAdmin();
        void EditPersonalityDesctription(string userId, string description);
    }
}
