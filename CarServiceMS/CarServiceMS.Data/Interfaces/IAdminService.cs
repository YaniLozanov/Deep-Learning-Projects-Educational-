using CarServiceMS.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarServiceMS.Data.Interfaces
{
    public interface IAdminService
    {
        IList<ApplicationUser> GetAllUsers();
        IList<ApplicationUser> GetAllAdmins();
        IList<ApplicationUser> GetAllBannedUsers();
        IList<ApplicationUser> GetAllOrinaryUsers();

        IList<Car> GetAllCars();
        ApplicationUser GetUserById(string id);


        Task ChangeUserRole(ApplicationUser user, string role);
        void DeleteAdmin();
        void EditPersonalityDesctription(string userId, string description);
    }
}
