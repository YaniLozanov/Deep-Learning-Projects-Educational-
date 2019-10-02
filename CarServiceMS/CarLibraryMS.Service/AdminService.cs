using CarServiceMS.Data;
using CarServiceMS.Data.Interfaces;
using CarServiceMS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarLibraryMS.Service
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext context;

        public AdminService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task ChangeUserRole(ApplicationUser user, string role)
        {
            user.Role = role;

            this.context.Users.Update(user);
           await this.context.SaveChangesAsync();
        }

        public void DeleteAdmin()
        {
            throw new NotImplementedException();
        }

        public IList<ApplicationUser> GetAllAdmins()
        {
            var adminRoleId = this.context.Roles.FirstOrDefault(role => role.Name == "Admin").Id;

            var adminsIds = this.context.UserRoles.Where(x => x.RoleId == adminRoleId).Select(x => x.UserId);

            var admins = this.context.User.Where(x => adminsIds.Contains(x.Id)).ToList();

            return admins;
        }
        public IList<ApplicationUser> GetAllBannedUsers()
        {
            var usersRoleId = this.context.Roles.FirstOrDefault(role => role.Name == "Banned").Id;

            var usersIds = this.context.UserRoles.Where(x => x.RoleId == usersRoleId).Select(x => x.UserId);

            var users = this.context.User.Where(x => usersIds.Contains(x.Id)).ToList();

            return users;
        }

        public IList<ApplicationUser> GetAllOrinaryUsers()
        {
            var usersRoleId = this.context.Roles.FirstOrDefault(role => role.Name == "User").Id;

            var usersIds = this.context.UserRoles.Where(x => x.RoleId == usersRoleId).Select(x => x.UserId).ToList();

            var users = this.context.User.Where(x => usersIds.Contains(x.Id)).ToList();

            return users;
        }

        public IList<ApplicationUser> GetAllUsers()
        {
            return this.context.Users
                .Include(user => user.Cars)
                .ToList();
        }
        public IList<Car> GetAllCars()
        {
            var cars = this.context.Cars.
                Include(car => car.Owner)
                .ThenInclude(owner => owner.Cars)
                .ToList();

            return cars;
        }

        public ApplicationUser GetUserById(string id)
        {
            return context.Users.SingleOrDefault(user => user.Id == id);
        }

        public void EditPersonalityDesctription(string userId, string description)
        {
            var user = GetUserById(userId);

            user.PersonalityDesctription = description;

            context.Users.Update(user);

            context.SaveChanges();

        }
    }
}
