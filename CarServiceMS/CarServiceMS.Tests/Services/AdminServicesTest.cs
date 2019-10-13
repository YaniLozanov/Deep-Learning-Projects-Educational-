using CarLibraryMS.Service;
using CarServiceMS.Data;
using CarServiceMS.Data.Models;
using CarServiceMS.Tests.Factories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarServiceMS.Tests.Services
{

    public class AdminServicesTest
    {

        [Fact]
        public async Task TestChangeUserRole_WithTestData_ShouldChangeUserRole()
        {
            var factory = new ApplicationDbContextFactory();
            var context = factory.CreateApplicationDbContext();
            var services = new AdminService(context);

            SeedDbWithUsers(context); // Count: 2
            var testUser = context.Users.FirstOrDefault();
            var testRole = "Admin";
            await services.ChangeUserRole(testUser, testRole);

            var expectedRole = testRole;
            var actualRole = context.Users
                .FirstOrDefault(user => user.UserName == testUser.UserName)
                .Role;

            Assert.Equal(expectedRole, actualRole);



        }
        [Fact]
        public void TestGetAllAdmins_WithTestData_ShouldGetAllAdmins()
        {
            var factory = new ApplicationDbContextFactory();
            var context = factory.CreateApplicationDbContext();
            var services = new AdminService(context);

            SeedDbWithAdmins(context); // Count: 2
            SeedDbWithUsers(context);  // Count: 2

            var expectedCount = 2;
            var actualCount = services.GetAllAdmins().Count;

            Assert.Equal(expectedCount, actualCount);


        }
        [Fact]
        public void TestGetAllBannedUsers_WithTestData_ShouldGetAllBannedUsers()
        {
            var factory = new ApplicationDbContextFactory();
            var context = factory.CreateApplicationDbContext();
            var services = new AdminService(context);

            SeedDbWithBanned(context); // Count: 2
            SeedDbWithUsers(context);  // Count: 2

            var expectedCount = 2;
            var actualCount = services.GetAllBannedUsers().Count;

            Assert.Equal(expectedCount, actualCount);


        }
        [Fact]
        public void TestGetAllOrdinatyUsers_WithTestData_ShouldGetAllOrdinaryUsers()
        {
            var factory = new ApplicationDbContextFactory();
            var context = factory.CreateApplicationDbContext();
            var services = new AdminService(context);


            SeedDbWithUsers(context); // Count: 2

            var expectedCount = 2;
            var actualCount = services.GetAllOrinaryUsers().Count;

            Assert.Equal(expectedCount, actualCount);


        }
        [Fact]
        public void TestGetAllUsers_WithTestData_ShouldGetAllUsers()
        {
            var factory = new ApplicationDbContextFactory();
            var context = factory.CreateApplicationDbContext();
            var services = new AdminService(context);

            SeedDbWithBanned(context); // Count: 2
            SeedDbWithAdmins(context); // Count: 2
            SeedDbWithUsers(context);  // Count: 2

            var expectedCount = 6;
            var actualCount = services.GetAllUsers().Count;

            Assert.Equal(expectedCount, actualCount);


        }
        [Fact]
        public void TestGetUserById_WithTestData_ShouldGetTheUserWithId()
        {
            var factory = new ApplicationDbContextFactory();
            var context = factory.CreateApplicationDbContext();
            var services = new AdminService(context);

            SeedDbWithUsers(context);  // Count: 2

            var user = context.Users.FirstOrDefault();

            var actualUser = services.GetUserById(user.Id);
            var expectedUser = user;

            Assert.True(expectedUser.Id == actualUser.Id && expectedUser.UserName == actualUser.UserName);


        }
        [Fact]
        public void TestGetAllCars_WithTestData_ShouldGetAllCars()
        {
            var factory = new ApplicationDbContextFactory();
            var context = factory.CreateApplicationDbContext();
            var services = new AdminService(context);

            SeedDbWithCars(context);  // Count: 2
            

            var actualCount = services.GetAllCars().Count;
            var expectedCount = 2;


            Assert.Equal(expectedCount, expectedCount);


        }



        private List<ApplicationUser> CreateUsers()
        {
            return new List<ApplicationUser>()
            {
                new ApplicationUser()
                {
                    UserName = "testUsername3",
                    Email = "test3@email.com",
                    PhoneNumber = "323456789",
                    Role = "User"

                },
                new ApplicationUser()
                {
                    UserName = "testUsername4",
                    Email = "test4@email.com",
                    PhoneNumber = "423456789",
                    Role = "User"

                }
            };
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
        private List<Car> CreateCars()
        {
            return new List<Car>()
            {
                new Car()
                {
                     Brand = "BMW",
                     Model = "X6",
                     Number = "PB1234K",
                     YearFrom = DateTime.Now
                },
                   new Car()
                {
                     Brand = "BMW",
                     Model = "X5",
                     Number = "PB1224K",
                     YearFrom = DateTime.Now
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
        private void SeedDbWithUsers(ApplicationDbContext context)
        {
            var users = CreateUsers();
            var userRole = CreateRoleUser();
            context.Roles.Add(userRole);
            context.AddRange(users);

            context.SaveChanges();

            context.UserRoles.Add(new IdentityUserRole<string>()
            {
                RoleId = context.Roles.FirstOrDefault(x => x.Name == "User").Id,
                UserId = context.Users.FirstOrDefault(x => x.UserName == "testUsername3").Id

            });
            context.UserRoles.Add(new IdentityUserRole<string>()
            {
                RoleId = context.Roles.FirstOrDefault(x => x.Name == "User").Id,
                UserId = context.Users.FirstOrDefault(x => x.UserName == "testUsername4").Id
            });

            context.SaveChanges();
        }
        private void SeedDbWithCars(ApplicationDbContext context)
        {
            context.Cars.AddRange(CreateCars());
            context.SaveChanges();
        }
    }
}
