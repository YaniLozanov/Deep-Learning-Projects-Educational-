using CarServiceMS.Data.Models;
using CarServiceMS.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarServiceMS.Services.Interfaces.AdminInterfaces
{
    public interface IAdminServices
    {
        IList<ApplicationUserServiceModel> GetAllAdmins();
        IList<ApplicationUserServiceModel> GetAllBannedUsers();
        IList<ApplicationUserServiceModel> GetAllOrinaryUsers();

        Task ChangeUserRoleAsync(ApplicationUserServiceModel user, string role);
        Task DeleteAdminAsync();
        Task EditPersonalityDesctriptionAsync(string userId, string description);

    }
}
