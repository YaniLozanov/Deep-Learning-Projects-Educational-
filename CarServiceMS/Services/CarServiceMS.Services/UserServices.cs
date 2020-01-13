using AutoMapper;
using CarServiceMS.Data;
using CarServiceMS.Service.Models;
using CarServiceMS.Services.Interfaces.UserInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CarServiceMS.Services
{
    public class UserServices : IUserServices
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public UserServices(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public ApplicationUserServiceModel GetUserById(string userId)
        {

            // ApplicationUser
            var userFromDb = context.Users
                .Include(user => user.Cars)
                .SingleOrDefault(user => user.Id == userId);

            // ApplicationUserServiceModel
            var applicationUserServiceModel = this.mapper.Map<ApplicationUserServiceModel>(userFromDb);

            return applicationUserServiceModel;

        }
        public ApplicationUserServiceModel GetUserByCarId(int id)
        {
            // ApplicationUser
            var userFromDb = this.context.User
               .Include(user => user.Cars)
               .SingleOrDefault(user => user.Cars.Any(car => car.Id == id));

            // ApplicationUserServiceModel
            var applicationUserServiceModel = this.mapper.Map<ApplicationUserServiceModel>(userFromDb);

            return applicationUserServiceModel;
        }
        public ApplicationUserServiceModel GetUserByName(string name)
        {
            // ApplicationUser
            var userFromDb = this.context.Users
               .Include(user => user.Cars)
               .FirstOrDefault(user => user.UserName == name);

            // ApplicationUserServiceModel
            var applicationUserServiceModel = this.mapper.Map<ApplicationUserServiceModel>(userFromDb);

            return applicationUserServiceModel;
        }
        public IList<ApplicationUserServiceModel> GetAllUsers()
        {
            var usersFromDb = this.context.Users
              .Include(user => user.Cars)
              .ToList();

            var applicationUserServiceModels = usersFromDb
                .Select(user => this.mapper.Map<ApplicationUserServiceModel>(user))
                .ToList();

            return applicationUserServiceModels;
        }
    }
}
