using CarServiceMS.Data;
using CarServiceMS.Data.Models;
using CarServiceMS.Services;
using CarServiceMS.Tests.Factories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CarServiceMS.Tests.Services
{
    public class UserServicesTests
    {
        // Tests for Method: GetUserById(userId)
        [Fact]
        public void TestGetUserById_WithTestData_ShouldGetTheUserWithId()
        {
            // Arrange
            var contextFactory = new ApplicationDbContextFactory();
            var context = contextFactory.CreateApplicationDbContext();

            var mapperFactory = new AutoMapperFactory();
            var mapper = mapperFactory.CreateMapper();

            var userServices = new UserServices(context, mapper);

            SeedDbWithUsers(context);  // Count: 2

            var user = context.Users.FirstOrDefault();

            var resultUser = userServices.GetUserById(user.Id);

            var actualUser = resultUser;
            var expectedUser = user;

            Assert.True(expectedUser.Id == actualUser.Id && expectedUser.UserName == actualUser.UserName);

        }

        // Tests for Method: GetUserByCarId(string carId);
        [Fact]
        public void TestGetUserByCarId_WithTestData_ShouldReturnTheUserWithCarId()
        {
            // Arrange
            var contextFactory = new ApplicationDbContextFactory();
            var context = contextFactory.CreateApplicationDbContext();

            var mapperFactory = new AutoMapperFactory();
            var mapper = mapperFactory.CreateMapper();


            var services = new UserServices(context, mapper);

            SeedDbWithUsers(context);
            SeedDbWithCars(context);
            SeedCarsToTheFirstUser(context);

            var carId = context.Cars.FirstOrDefault().Id;
            var user = context.Users.FirstOrDefault(x => x.Cars.Any(car => car.Id == carId));

            // Act
            var result = services.GetUserByCarId(carId);

            var expectedUser = user;
            var actualUser = result;

            Assert.True(expectedUser.Id == actualUser.Id &&
                expectedUser.UserName == actualUser.UserName &&
                expectedUser.Email == actualUser.Email,
                "The method: GetUserById(string userId) does not work correctly!");

        }
        [Fact]
        public void TestGetUserByCarId_WithoutUser_ShouldReturnNull()
        {
            // Arrange
            var contextFactory = new ApplicationDbContextFactory();
            var context = contextFactory.CreateApplicationDbContext();

            var mapperFactory = new AutoMapperFactory();
            var mapper = mapperFactory.CreateMapper();

            var services = new UserServices(context, mapper);

            SeedDbWithCars(context);
          

            var carId = context.Cars.FirstOrDefault().Id;
          
            // Act
            var result = services.GetUserByCarId(carId);

            var actualUser = result;

            // Assert
            Assert.True(null == actualUser,
                "The method: GetUserById(string userId) does not work correctly!");

        }

        // Tests for Method: GetUserByName(string name).
        [Fact]
        public void TestGetUserByName_WithTestData_ShouldReturnTheUserWithName()
        {
            // Arrange
            var contextFactory = new ApplicationDbContextFactory();
            var context = contextFactory.CreateApplicationDbContext();

            var mapperFactory = new AutoMapperFactory();
            var mapper = mapperFactory.CreateMapper();

            var services = new UserServices(context, mapper);


            SeedDbWithUsers(context);

            var testUsername = "Test_User_1";

            var user = context.Users.FirstOrDefault(x => x.UserName == testUsername);

            // Act
            var resultUser = services.GetUserByName(testUsername);

            var expectedUser = user;
            var actualUser = resultUser;

            // Assert   
            Assert.True(expectedUser.Id == actualUser.Id &&
                expectedUser.UserName == actualUser.UserName &&
                expectedUser.Email == actualUser.Email);

        }
        [Fact]
        public void TestGetAllUsers_WithTestData_ShouldGetAllUsers()
        {
            // Arrange
            var contextFactory = new ApplicationDbContextFactory();
            var context = contextFactory.CreateApplicationDbContext();

            var mapperFactory = new AutoMapperFactory();
            var mapper = mapperFactory.CreateMapper();

            var services = new UserServices(context, mapper);
            SeedDbWithBanned(context); // Count: 2
            SeedDbWithAdmins(context); // Count: 2
            SeedDbWithUsers(context);  // Count: 2

            var resultCount = services.GetAllUsers().Count();

            var expectedCount = context.Users.Count();
            var actualCount = resultCount;

            Assert.Equal(expectedCount, actualCount);
        }



        // Private Methods.
        private void SeedCarsToTheFirstUser(ApplicationDbContext context)
        {
            var user = context.Users.FirstOrDefault();
            var cars = context.Cars.ToList();

            foreach (var car in cars)
            {
                context.Update(car);
                car.Owner = user;
            }


            context.SaveChanges();
        }



        private void SeedDbWithAdmins(ApplicationDbContext context)
        {
            var admins = CreateAdmins();
            var adminRole = CreateRoleAdmin();
            context.Roles.Add(adminRole);
            context.AddRange(admins);

            context.SaveChanges();

            context.UserRoles.Add(new IdentityUserRole<string>()
            {
                RoleId = context.Roles.FirstOrDefault(x => x.Name == "Admin").Id,
                UserId = context.Users.FirstOrDefault(x => x.UserName == "testUsername1").Id

            });
            context.UserRoles.Add(new IdentityUserRole<string>()
            {
                RoleId = context.Roles.FirstOrDefault(x => x.Name == "Admin").Id,
                UserId = context.Users.FirstOrDefault(x => x.UserName == "testUsername2").Id

            });

            context.SaveChanges();
        }
        private void SeedDbWithBanned(ApplicationDbContext context)
        {
            var banned = CreateBannedUsers();
            var bannedRole = CreateRoleBanned();
            context.Roles.Add(bannedRole);
            context.AddRange(banned);

            context.SaveChanges();

            context.UserRoles.Add(new IdentityUserRole<string>()
            {
                RoleId = context.Roles.FirstOrDefault(x => x.Name == "Banned").Id,
                UserId = context.Users.FirstOrDefault(x => x.UserName == "testUsername5").Id

            });
            context.UserRoles.Add(new IdentityUserRole<string>()
            {
                RoleId = context.Roles.FirstOrDefault(x => x.Name == "Banned").Id,
                UserId = context.Users.FirstOrDefault(x => x.UserName == "testUsername6").Id

            });

            context.SaveChanges();
        }
        private void SeedDbWithCars(ApplicationDbContext context)
        {
            context.Cars.AddRange(CreateCars());
            context.SaveChanges();
        }
        private void SeedDbWithUsers(ApplicationDbContext context)
        {
            context.Users.AddRange(CreateUsers());
            context.SaveChanges();
        }

        private List<ApplicationUser> CreateAdmins()
        {
            return new List<ApplicationUser>()
            {
                new ApplicationUser()
                {
                    UserName = "testUsername1",
                    Email = "test1@email.com",
                    PhoneNumber = "123456789",
                    Role = "Admin"

                },
                new ApplicationUser()
                {
                    UserName = "testUsername2",
                    Email = "test2@email.com",
                    PhoneNumber = "223456789",
                    Role = "Admin"

                }
            };
        }
        private List<ApplicationUser> CreateBannedUsers()
        {
            return new List<ApplicationUser>()
            {
                new ApplicationUser()
                {
                    UserName = "testUsername5",
                    Email = "test5@email.com",
                    PhoneNumber = "523456789",
                    Role = "Banned"

                },
                new ApplicationUser()
                {
                    UserName = "testUsername6",
                    Email = "test6@email.com",
                    PhoneNumber = "623456789",
                    Role = "Banned"

                }
            };
        }


        private IdentityRole CreateRoleAdmin()
        {
            return new IdentityRole()
            {
                Name = "Admin"
            };
        }
        private IdentityRole CreateRoleBanned()
        {
            return new IdentityRole()
            {
                Name = "Banned"
            };
        }
        private IdentityRole CreateRoleUser()
        {
            return new IdentityRole()
            {
                Name = "User"
            };
        }

        private List<ApplicationUser> CreateUsers()
        {
            return new List<ApplicationUser>()
            {
                new ApplicationUser()
                {
                    UserName = "Test_User_1",
                    Email = "test1@emai.com",
                    PhoneNumber = "12345679"
                },
                new ApplicationUser()
                {
                    UserName = "Test_User_2",
                    Email = "test2@emai.com",
                    PhoneNumber = "22345679"
                }
            };
        }
        private IList<Car> CreateCars()
        {
            return new List<Car>()
            {
                new Car(){

                    Brand = "BMW",
                    Model = "X6",
                    Number = "PB1234K",
                    YearFrom = DateTime.Now
                },
                 new Car(){

                    Brand = "Audi",
                    Model = "Q7",
                    Number = "PB77777",
                    YearFrom = DateTime.Now
                }
            };
        }

    }
}
