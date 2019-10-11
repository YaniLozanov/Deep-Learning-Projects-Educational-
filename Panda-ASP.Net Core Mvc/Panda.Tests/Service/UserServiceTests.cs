using Microsoft.EntityFrameworkCore;
using Panda.Data;
using Panda.Domain;
using Panda.Services;
using Panda.Tests.Extensions;
using Panda.Tests.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Panda.Tests.Service
{
    public class UserServiceTests
    {
        [Fact]
        public void TestGetAllUsers_WithTestData_ShouldReturnAllUsers()
        {
            var factory = new PandaDbContextFactory();

            var context = factory.CreatePandaDbContext();

            this.SeedTestData(context);

            var usersService = new UsersService(context);

            var expectedData = GetTestData();
            var actualData = usersService.GetAllUsers();

            Assert.Equal(expectedData.Count, actualData.Count);

            foreach (var actualUser in actualData)
            {
                Assert.True(expectedData.Any(x =>
                x.UserName == actualUser.UserName
                && x.Email == actualUser.Email
                && x.UserRole.Name == actualUser.UserRole.Name),
                "UsersService GetAllUsers() method does not work porperly!");
            }

        }

        [Fact]
        public void TestGetAllUsers_WithoutAnyData_ShouldReturnEmptyList()
        {
            var factory = new PandaDbContextFactory();

            var context = factory.CreatePandaDbContext();


            var usersService = new UsersService(context);

            var actualData = usersService.GetAllUsers();

            Assert.True(actualData.Count == 0, "UsersService GetAllUsers() method does not work properly!");

       

        }

        [Fact]
        public void TestGetUser_WithExistentUsername_ShouldReturnUser()
        {

            var factory = new PandaDbContextFactory();

            var context = factory.CreatePandaDbContext();
            this.SeedTestData(context);

            var usersService = new UsersService(context);

            string testUsername = "TestUser1";

            var expectedData = GetTestData().SingleOrDefault(user => user.UserName == testUsername);
            var actualData = usersService.GetUser(testUsername);

            AssertExtensions.EqualsWithMessage(
                expectedData.UserName,
                actualData.UserName,
                "UsersService GetUser() does not work properly!");


            AssertExtensions.EqualsWithMessage(
                expectedData.Email,
                actualData.Email,
                "UsersService GetUser() does not work properly!");


            AssertExtensions.EqualsWithMessage(
                expectedData.UserRole.Name,
                actualData.UserRole.Name,
                "UsersService GetUser() does not work properly!");

        }

        [Fact]
        public void TestGetUser_WithNonExistentUsername_ShouldReturnNull()
        {

            var factory = new PandaDbContextFactory();

            var context = factory.CreatePandaDbContext();
            this.SeedTestData(context);

            var usersService = new UsersService(context);

            string testUsername = "TestUserNon";

            var actualData = usersService.GetUser(testUsername);

            Assert.True(actualData == null,
                "UsersService GetUser() does not work properly!");
          

        }

        private void SeedTestData(PandaDbContext context)
        {
            context.Users.AddRange(GetTestData());
            context.SaveChanges();
        }

        private List<PandaUser> GetTestData()
        {
            return new List<PandaUser>()
            {
                new PandaUser
                {
                    UserName = "TestUser1",
                    Email = "test1@email.com",
                    UserRole = new PandaUserRole() { Name = "Admin"}
                },
                new PandaUser
                {
                    UserName = "TestUser2",
                    Email = "test2@email.com",
                    UserRole = new PandaUserRole() { Name = "User"}
                }
            };
        }
    }
}
