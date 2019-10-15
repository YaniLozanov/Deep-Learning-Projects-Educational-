using CarLibraryMS.Service;
using CarServiceMS.Data;
using CarServiceMS.Data.Models;
using CarServiceMS.Tests.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CarServiceMS.Tests.Services
{
    // TODO: BUG: When I run all tests at the same time, they do not pass.

    public class CarServicesTests
    {
        [Fact]
        public void TestAddCar_WithTestData_ShouldAddCarToDb()
        {
            var factory = new ApplicationDbContextFactory();
            var context = factory.CreateApplicationDbContext();
            var services = new CarService(context);

            var car = new Car()
            {
                Brand = "BMW",
                Model = "X6",
                Number = "PB1234K",
                YearFrom = DateTime.Now
            };

            services.AddCar(car);

            var expectedCount = 1;
            var actualCount = context.Cars.Count();

            Assert.Equal(expected: expectedCount, actual: actualCount);

        }
        [Fact]
        public void TestRemoveCar_WithTestData_ShouldRemoveCarFromDb()
        {
            var factory = new ApplicationDbContextFactory();
            var context = factory.CreateApplicationDbContext();
            var services = new CarService(context);

            SeedDbWithCars(context);
            var carId = context.Cars.FirstOrDefault().Id;

            services.RemoveCar(carId);

            var expectedCount = 1;
            var actualCount = context.Cars.Count();

            Assert.Equal(expected: expectedCount, actual: actualCount);
        }
        [Fact]
        public void TestEditCarData_WithTestData_ShouldEditTheCarsData()
        {
            var factory = new ApplicationDbContextFactory();
            var context = factory.CreateApplicationDbContext();
            var services = new CarService(context);

            SeedDbWithCars(context); // Count: 2

            var car = context.Cars.FirstOrDefault();

            car.Brand = "Tesla";
            car.Model = "Model S";

            services.EditCarData(car);
            var carFormDb = context.Cars.FirstOrDefault(c => c.Id == car.Id);

            var expectedBrand = "Tesla";
            var expectedModel = "Model S";

            var actualBrand = carFormDb.Brand;
            var actualModel = carFormDb.Model;

            Assert.True(expectedBrand == actualBrand
                && expectedModel == actualModel,
                "The method EditCarData does not work!");

            
        }
        [Fact]
        public void TestGetCarById_WithTestData_ShouldReturnTheCarWithId()
        {
            var factory = new ApplicationDbContextFactory();
            var context = factory.CreateApplicationDbContext();
            var services = new CarService(context);

            SeedDbWithCars(context); // Count: 2

            var car = context.Cars.FirstOrDefault();
            var carId = car.Id;

            var expetedCar= car;
            var actualCar = services.GetCarById(carId);

            Assert.True(expetedCar.Id == actualCar.Id &&
                expetedCar.Brand == actualCar.Brand &&
                expetedCar.Model == actualCar.Model &&
                expetedCar.Number == actualCar.Number); 
        }
        [Fact]
        public void TestGetAllCarsForUserWithId_WithTestData_ShouldReturnAllCarsForTheUserWithId()
        {
            var factory = new ApplicationDbContextFactory();
            var context = factory.CreateApplicationDbContext();
            var services = new CarService(context);

            SeedDbWithUsers(context);
            SeedDbWithCars(context);
            SeedCarsToTheFirstUser(context);

            var firstUser = context.Users.FirstOrDefault();

            var expectedCount = 2;
            var actualCount = services.GetAllCarsForUserWithId(firstUser.Id).Count();

            Assert.Equal(expectedCount, actualCount);
           
        }
        [Fact]
        public void TestGetUserByCarId_WithTestData_ShouldReturnTheUserWithCarId()
        {
            var factory = new ApplicationDbContextFactory();
            var context = factory.CreateApplicationDbContext();
            var services = new CarService(context);

            SeedDbWithUsers(context);
            SeedDbWithCars(context);
            SeedCarsToTheFirstUser(context);

            var carId = context.Cars.FirstOrDefault().Id;
            var user = context.Users.FirstOrDefault(x => x.Cars.Any(car => car.Id == carId));

            var expectedUser = user;
            var actualUser = services.GetUserByCarId(carId);

            Assert.True(expectedUser.Id == actualUser.Id &&
                expectedUser.UserName == actualUser.UserName &&
                expectedUser.Email == actualUser.Email);

        }
        [Fact]
        public void TestGetUserByName_WithTestData_ShouldReturnTheUserWithName()
        {
            var factory = new ApplicationDbContextFactory();
            var context = factory.CreateApplicationDbContext();
            var services = new CarService(context);

            SeedDbWithUsers(context);

            var testUsername = "Test_User_1";

            var user = context.Users.FirstOrDefault(x => x.UserName == testUsername);

            var expectedUser = user;
            var actualUser = services.GetUserByName(testUsername);

            Assert.True(expectedUser.Id == actualUser.Id &&
                expectedUser.UserName == actualUser.UserName &&
                expectedUser.Email == actualUser.Email);

        }
        [Fact]
        public void TestIsThereSuchCarWithNumber_WithTestData_ShouldReturnIsThereSuchCarWithNumberTrue()
        {
            var factory = new ApplicationDbContextFactory();
            var context = factory.CreateApplicationDbContext();
            var services = new CarService(context);

            SeedDbWithCars(context);

            var testNumber = "PB1234K";

            Assert.True(services.IsThereSuchCarWithNumber(testNumber));

        }
        [Fact]
        public void TestIsThereSuchCarWithNumber_WithTestData_ShouldReturnIsThereSuchCarWithNumberFalse()
        {
            var factory = new ApplicationDbContextFactory();
            var context = factory.CreateApplicationDbContext();
            var services = new CarService(context);

            SeedDbWithCars(context);

            var testNumber = "PA1234K";

            Assert.False(services.IsThereSuchCarWithNumber(testNumber));

        }


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
        private List<Car> CreateCars()
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
