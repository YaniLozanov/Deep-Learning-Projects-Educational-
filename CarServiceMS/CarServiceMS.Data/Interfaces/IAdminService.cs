using CarServiceMS.Data.Models;
using System.Collections.Generic;

namespace CarServiceMS.Data.Interfaces
{
    public interface IAdminService
    {
        IEnumerable<ApplicationUser> GetAllUsers();
        void BanUser(string username);
        void DeleteAdmin();
        void GetAllAdmins();
    }
}
