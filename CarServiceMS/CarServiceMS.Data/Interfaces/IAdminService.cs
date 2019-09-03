using CarServiceMS.Data.Models;
using System.Collections.Generic;

namespace CarServiceMS.Data.Interfaces
{
    public interface IAdminService
    {
        IList<ApplicationUser> GetAllUsers();
        IList<ApplicationUser> GetAllAdmins();

        void BanUser(string username);
        void DeleteAdmin();
    }
}
