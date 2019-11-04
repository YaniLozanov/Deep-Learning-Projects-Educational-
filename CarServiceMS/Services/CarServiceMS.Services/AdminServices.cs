using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarServiceMS.Data;
using CarServiceMS.Data.Models;
using CarServiceMS.Service.Models;
using CarServiceMS.Services.Interfaces.AdminInterfaces;
using CarServiceMS.Services.Interfaces.UserInterfaces;

namespace CarServiceMS.Services
{
    public class AdminServices : IAdminServices
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AdminServices(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IList<ApplicationUserServiceModel> GetAllAdmins()
        {
            return this.GetUsersWithRoleName("Admin");
        }
        public IList<ApplicationUserServiceModel> GetAllBannedUsers()
        {
            return this.GetUsersWithRoleName("Banned");
        }
        public IList<ApplicationUserServiceModel> GetAllOrinaryUsers()
        {
            return this.GetUsersWithRoleName("User");
        }
        private IList<ApplicationUserServiceModel> GetUsersWithRoleName(string roleName)
        {
            try
            {
                var usersRoleId = this.context.Roles.FirstOrDefault(role => role.Name == roleName).Id;

                var usersIds = this.context.UserRoles.Where(x => x.RoleId == usersRoleId).Select(x => x.UserId).ToList();

                var users = this.context.User.Where(x => usersIds.Contains(x.Id)).ToList();

                var applicationUserServiceModels = users
                    .Select(user => this.mapper.Map<ApplicationUserServiceModel>(user))
                    .ToList();

                return applicationUserServiceModels;
            }
            catch (NullReferenceException e)
            {

                throw new ArgumentException("There are no Users in this Role!", e);
            }
        }

        public Task DeleteAdminAsync()
        {
            // TODO
            throw new System.NotImplementedException("This Method is not Implement yet.");
        }// TODO
        public async Task ChangeUserRoleAsync(ApplicationUserServiceModel user, string role)
        {
            if (user != null && role != null)
            {
                var userFromDb = this.context.Users.FirstOrDefault(u => u.Id == user.Id);

                this.context.Users.Update(userFromDb);

                userFromDb.Role = role;

                await this.context.SaveChangesAsync();
            }
        }
        public async Task EditPersonalityDesctriptionAsync(string userId, string description)
        {
            if (userId != null)
            {
                var user = this.context.User.FirstOrDefault(u => u.Id == userId);

                var applicationUser = this.mapper.Map<ApplicationUser>(user);

                this.context.Users.Update(applicationUser);

                applicationUser.PersonalityDesctription = description;

                await this.context.SaveChangesAsync();
            }
        }
    }
}
