using CarServiceMS.Data;
using CarServiceMS.Data.Models;
using CarServiceMS.Service.Models;
using CarServiceMS.Services;
using CarServiceMS.Tests.Factories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CarServiceMS.Tests.Services
{
    // TODO: To Fix the bug: When I run all tests together, they fail.

    public class AdminServicesTests
    {
        // Tests for Method: GetAllAdmins().
        [Fact]
        public void TestGetAllAdmins_WithTestData_ShouldReturnAllUsersInRoleAdmin()
        {
    
            // Arrange
            var contextFactory = new ApplicationDbContextFactory();
            var context = contextFactory.CreateApplicationDbContext();

            var mapperFactory = new AutoMapperFactory();
            var mapper = mapperFactory.CreateMapper();

            var adminServices = new AdminServices(context, mapper);

            SeedDbWithAdmins(context); // Count: 2
            SeedDbWithUsers(context);   // Count: 2

            // Act
            var actualAdminsCount = adminServices.GetAllAdmins().Count();

            var expextedCount = context.Users.Where(user => user.Role == "Admin").Count(); // Expected Count: 2
            var actualCount = actualAdminsCount;

            // Assert 
            Assert.Equal(expected: expextedCount, actual: actualCount);
            Thread.Sleep(3000);
        }
        [Fact]
        public void TestGetAllAdmins_WithoutTestData_ShouldThrowsArgumentException()
        {
            var contextFactory = new ApplicationDbContextFactory();
            var context = contextFactory.CreateApplicationDbContext();

            var mapperFactory = new AutoMapperFactory();
            var mapper = mapperFactory.CreateMapper();

            var adminServices = new AdminServices(context, mapper);

            SeedDbWithUsers(context);   // Count: 2
            context.Roles.Add(CreateRoleAdmin());

            Assert.Throws<ArgumentException>(() => adminServices.GetAllAdmins().Count());
        }


        // Tests for Method: GetAllBannedUsers().
        [Fact]
        public void TestGetAllBannedUsers_WithTestData_ShouldReturnAllUsersInRoleBanned()
        {
            // Arrange
            var contextFactory = new ApplicationDbContextFactory();
            var context = contextFactory.CreateApplicationDbContext();

            var mapperFactory = new AutoMapperFactory();
            var mapper = mapperFactory.CreateMapper();

            var adminServices = new AdminServices(context, mapper);

            SeedDbWithBanned(context); // Count: 2
            SeedDbWithUsers(context);   // Count: 2

            // Act
            var actualBannedUsersCount = adminServices.GetAllBannedUsers().Count();

            var expextedCount = context.Users.Where(user => user.Role == "Banned").Count(); // Expected Count: 2
            var actualCount = actualBannedUsersCount;

            // Assert 
            Assert.Equal(expected: expextedCount, actual: actualCount);

        }
        [Fact]
        public void TestGetAllBannedUsers_WithoutTestData_ShouldThrowsArgumentException()
        {
            var contextFactory = new ApplicationDbContextFactory();
            var context = contextFactory.CreateApplicationDbContext();

            var mapperFactory = new AutoMapperFactory();
            var mapper = mapperFactory.CreateMapper();

            var adminServices = new AdminServices(context, mapper);

            SeedDbWithUsers(context);   // Count: 2
            context.Roles.Add(CreateRoleAdmin());

            Assert.Throws<ArgumentException>(() => adminServices.GetAllBannedUsers().Count());
        }


        // Tests for Method: GetAllOrinaryUsers().
        [Fact]
        public void TestGetAllOrinaryUsers_WithTestData_ShouldReturnAllUsersInRoleUser()
        {
            // Arrange
            var contextFactory = new ApplicationDbContextFactory();
            var context = contextFactory.CreateApplicationDbContext();

            var mapperFactory = new AutoMapperFactory();
            var mapper = mapperFactory.CreateMapper();

            var adminServices = new AdminServices(context, mapper);

            SeedDbWithBanned(context); // Count: 2
            SeedDbWithUsers(context);   // Count: 2

            // Act
            var actualOrdanaryUsersCount = adminServices.GetAllOrinaryUsers().Count();

            var expextedCount = context.Users.Where(user => user.Role == "User").Count(); // Expected Count: 2
            var actualCount = actualOrdanaryUsersCount;

            // Assert 
            Assert.Equal(expected: expextedCount, actual: actualCount);

        }
        [Fact]
        public void TestGetAllOrinaryUsers_WithoutTestData_ShouldThrowsArgumentException()
        {
            var contextFactory = new ApplicationDbContextFactory();
            var context = contextFactory.CreateApplicationDbContext();

            var mapperFactory = new AutoMapperFactory();
            var mapper = mapperFactory.CreateMapper();

            var adminServices = new AdminServices(context, mapper);

            SeedDbWithAdmins(context); // Count: 2

            context.Roles.Add(CreateRoleAdmin());

            Assert.Throws<ArgumentException>(() => adminServices.GetAllOrinaryUsers().Count());
        }


        // Tests for Method: ChangeUserRoleAsync(ApplicationUserServiceModel user, string role).
        [Fact]
        public async Task TestChangeUserRoleAsync_WithTestData_ShouldChangeUsersRole()
        {
            // Arrange
            var contextFactory = new ApplicationDbContextFactory();
            var context = contextFactory.CreateApplicationDbContext();

            var mapperFactory = new AutoMapperFactory();
            var mapper = mapperFactory.CreateMapper();

            var adminServices = new AdminServices(context, mapper);

            SeedDbWithUsers(context); // Count: 2

            var testApplicationUser = context.Users.FirstOrDefault(); // Take the first user.
            var testRole = "Admin";
            var testApplicationUserServiceModel = mapper.Map<ApplicationUserServiceModel>(testApplicationUser);

            // Act
            await adminServices.ChangeUserRoleAsync(testApplicationUserServiceModel, testRole);

            var expectedRole = testRole;
            var actualRole = context.Users
                .FirstOrDefault(user => user.UserName == testApplicationUserServiceModel.UserName)
                .Role;

            // Assert
            Assert.Equal(expectedRole, actualRole);

        }
        [Fact]
        public async Task TestChangeUserRoleAsync_WithUserNull_ShouldNotChangeUsersRole()
        {
            // Arrange
            var contextFactory = new ApplicationDbContextFactory();
            var context = contextFactory.CreateApplicationDbContext();

            var mapperFactory = new AutoMapperFactory();
            var mapper = mapperFactory.CreateMapper();

            var adminServices = new AdminServices(context, mapper);

            SeedDbWithUsers(context); // Count: 2

            var testApplicationUser = context.Users.FirstOrDefault(); // Take the first user.
            var testRole = "Admin";

            // Act
            await adminServices.ChangeUserRoleAsync(null, testRole);
            var testApplicationUserServiceModel = mapper.Map<ApplicationUserServiceModel>(testApplicationUser);

            var expectedRole = "User";
            var actualRole = context.Users
                .FirstOrDefault(user => user.UserName == testApplicationUserServiceModel.UserName)
                .Role;

            // Assert
            Assert.Equal(expectedRole, actualRole);

        }
        [Fact]
        public async Task TestChangeUserRoleAsync_WithRoleNull_ShouldNotChangeUsersRole()
        {
            // Arrange
            var contextFactory = new ApplicationDbContextFactory();
            var context = contextFactory.CreateApplicationDbContext();

            var mapperFactory = new AutoMapperFactory();
            var mapper = mapperFactory.CreateMapper();

            var adminServices = new AdminServices(context, mapper);

            SeedDbWithUsers(context); // Count: 2

            var testApplicationUser = context.Users.FirstOrDefault(); // Take the first user.
         
            var testApplicationUserServiceModel = mapper.Map<ApplicationUserServiceModel>(testApplicationUser);

            // Act
            await adminServices.ChangeUserRoleAsync(testApplicationUserServiceModel, null);

            var expectedRole = "User";
            var actualRole = context.Users
                .FirstOrDefault(user => user.UserName == testApplicationUserServiceModel.UserName)
                .Role;

            // Assert
            Assert.Equal(expectedRole, actualRole);

        }


        // Tests for Method: EditPersonalityDesctriptionAsync(string userId, string description).
        [Fact]
        public async Task TestEditPersonalityDesctriptionAsync_WithTestData_ShouldEditThePersonalityDescription()
        {
            // Arrange
            var contextFactory = new ApplicationDbContextFactory();
            var context = contextFactory.CreateApplicationDbContext();

            var mapperFactory = new AutoMapperFactory();
            var mapper = mapperFactory.CreateMapper();

            var adminServices = new AdminServices(context, mapper);

            SeedDbWithUsers(context); // Count: 2

            var testApplicationUser = context.Users.FirstOrDefault(); // Take the first user.
            var userId = testApplicationUser.Id;
            var newPersonalityDesctription = "Test Description!";
          

            // Act
            await adminServices.EditPersonalityDesctriptionAsync(userId, newPersonalityDesctription);

            var expectedDescription = newPersonalityDesctription;
            var actualRole = context.Users
                .FirstOrDefault(user => user.Id == userId)
                .PersonalityDesctription;

            // Assert
            Assert.Equal(expectedDescription, actualRole);

        }
        [Fact]
        public async Task TestEditPersonalityDesctriptionAsync_WithWithUserIdNull_ShouldNotEditThePersonalityDescription()
        {
            // Arrange
            var contextFactory = new ApplicationDbContextFactory();
            var context = contextFactory.CreateApplicationDbContext();

            var mapperFactory = new AutoMapperFactory();
            var mapper = mapperFactory.CreateMapper();

            var adminServices = new AdminServices(context, mapper);

            SeedDbWithUsers(context); // Count: 2

            var testApplicationUser = context.Users.FirstOrDefault(); // Take the first user.
            var userId = testApplicationUser.Id;
            var newPersonalityDesctription = "Test Description!";


            // Act
            await adminServices.EditPersonalityDesctriptionAsync(null, newPersonalityDesctription);

            var expectedDescription = testApplicationUser.PersonalityDesctription;
            var actualDescription = context.Users
                .FirstOrDefault(user => user.Id == userId)
                .PersonalityDesctription;

            // Assert
            Assert.Equal(expected: expectedDescription, actual: actualDescription);

        }
        [Fact]
        public async Task TestEditPersonalityDesctriptionAsync_WithWithDescriptionIdNull_ShouldNotClearThePersonalityDescription()
        {
            // Arrange
            var contextFactory = new ApplicationDbContextFactory();
            var context = contextFactory.CreateApplicationDbContext();

            var mapperFactory = new AutoMapperFactory();
            var mapper = mapperFactory.CreateMapper();

            var adminServices = new AdminServices(context, mapper);

            SeedDbWithUsers(context); // Count: 2

            var testApplicationUser = context.Users.FirstOrDefault(); // Take the first user.
            var userId = testApplicationUser.Id;


            // Act
            await adminServices.EditPersonalityDesctriptionAsync(userId, null);

            var actualDescription = context.Users
                .FirstOrDefault(user => user.Id == userId)
                .PersonalityDesctription;

            // Assert
            Assert.Equal(expected: null, actual: actualDescription);

        }


        // Private Methods.
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
