using CarServiceMS.Data;
using CarServiceMS.Data.Interfaces;
using CarServiceMS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CarLibraryMS.Service
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext context;

        public AdminService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void BanUser(string username)
        {
            throw new NotImplementedException();
        }

        public void DeleteAdmin()
        {
            throw new NotImplementedException();
        }

        public void GetAllAdmins()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return this.context.Users
                .Include(user => user.Cars);
        }
    }
}
