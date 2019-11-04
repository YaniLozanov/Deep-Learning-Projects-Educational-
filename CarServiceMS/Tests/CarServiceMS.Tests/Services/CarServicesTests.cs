using CarServiceMS.Data;
using CarServiceMS.Data.Models;
using CarServiceMS.Service.Models;
using CarServiceMS.Services;
using CarServiceMS.Tests.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CarServiceMS.Tests.Services
{
    public class CarServicesTests
    {
        // Tests for Method: AddCarAsync(CarServiceModel carServiceModel).
        [Fact]
        public async Task TestAddCarAsync_WithTestData_ShouldAddCarToDb()
        {
            // Arrange
            var contextFactory = new ApplicationDbContextFactory();
            var context = contextFactory.CreateApplicationDbContext();

            var mapperFactory = new AutoMapperFactory();
            var mapper = mapperFactory.CreateMapper();

            var carServices = new CarServices(context, mapper);

            var car = new Car()
            {
                Brand = "BMW",
                Model = "X6",
                Number = "PB1234K",
                YearFrom = DateTime.Now
            };
            var carServiceModel = mapper.Map<CarServiceModel>(car);

            // Act
            await carServices.AddCarAsync(carServiceModel);

            var expectedCount = 1;
            var actualCount = context.Cars.Count();

            // Assert
            Assert.Equal(expected: expectedCount, actual: actualCount);

        }
        [Fact]
        public async Task TestAddCarAsync_WithCarServiceModelNull_ShouldNotAddCarToDb()
        {
            // Arrange
            var contextFactory = new ApplicationDbContextFactory();
            var context = contextFactory.CreateApplicationDbContext();

            var mapperFactory = new AutoMapperFactory();
            var mapper = mapperFactory.CreateMapper();

            var carServices = new CarServices(context, mapper);


            // Act
            await carServices.AddCarAsync(null);

            var expectedCount = 0;
            var actualCount = context.Cars.Count();

            // Assert
            Assert.Equal(expected: expectedCount, actual: actualCount);

        }


        // Tests for Method: EditCarDataAsync(CarServiceModel carServiceModel).
        [Fact]
        public async Task TestEditCarDataAsync_WithTestData_ShouldEditTheCarData()
        {
            // Arrange
            var contextFactory = new ApplicationDbContextFactory();
            var context = contextFactory.CreateApplicationDbContext();

            var mapperFactory = new AutoMapperFactory();
            var mapper = mapperFactory.CreateMapper();

            SeedDbWithCars(context);

            var carServices = new CarServices(context, mapper);
            var car = context.Cars.FirstOrDefault();
            var carServiceModel = mapper.Map<CarServiceModel>(car);

            carServiceModel.Brand = "Tesla";
            carServiceModel.Model = "Model S";

            // Act
            await carServices.EditCarDataAsync(carServiceModel);

            var carFormDb = context.Cars.FirstOrDefault(c => c.Id == car.Id);

            var expectedBrand = "Tesla";
            var expectedModel = "Model S";

            var actualBrand = carFormDb.Brand;
            var actualModel = carFormDb.Model;

            // Assert
            Assert.True(expectedBrand == actualBrand
                && expectedModel == actualModel,
                "The method EditCarDataAsnc does not work!");

        }
        [Fact]
        public async Task TestEditCarDataAsync_WithCarServiceModelNull_ShouldNotEditTheCarData()
        {
            // Arrange
            var contextFactory = new ApplicationDbContextFactory();
            var context = contextFactory.CreateApplicationDbContext();

            var mapperFactory = new AutoMapperFactory();
            var mapper = mapperFactory.CreateMapper();

            SeedDbWithCars(context);

            var carServices = new CarServices(context, mapper);
            var car = context.Cars.FirstOrDefault();


            // Act
            await carServices.EditCarDataAsync(null);

            var carFormDb = context.Cars.FirstOrDefault(c => c.Id == car.Id);

            var expectedBrand = car.Brand;
            var expectedModel = car.Model;

            var actualBrand = carFormDb.Brand;
            var actualModel = carFormDb.Model;

            // Assert
            Assert.True(expectedBrand == actualBrand
                && expectedModel == actualModel,
                "The method EditCarDataAsnc does not work!");

        }


        // Tests for Method: DeleteCarAsync(int carId).
        [Fact]
        public async Task TestDeleteCarAsync_WithTestData_ShouldDeleteCarrFromDb()
        {
            // Arrange
            var contextFactory = new ApplicationDbContextFactory();
            var context = contextFactory.CreateApplicationDbContext();

            var mapperFactory = new AutoMapperFactory();
            var mapper = mapperFactory.CreateMapper();

            SeedDbWithCars(context);

            var carServices = new CarServices(context, mapper);
            var carId = context.Cars.FirstOrDefault().Id;

            // Act
            await carServices.DeleteCarAsync(carId);

            var expectedCount = 1;
            var actualCount = context.Cars.Count();

            // Assert
            Assert.Equal(expected: expectedCount, actual: actualCount);
        }


        // Tests for Method: GetAllCars().
        [Fact]
        public void TestGetAllCars_WithTestData_ShouldGetAllCars()
        {
            // Arrange
            var contextFactory = new ApplicationDbContextFactory();
            var context = contextFactory.CreateApplicationDbContext();

            var mapperFactory = new AutoMapperFactory();
            var mapper = mapperFactory.CreateMapper();

            var carServices = new CarServices(context, mapper);

            SeedDbWithCars(context);

            // Act
            var actualCount = carServices.GetAllCars().Count();
            var expectedCount = 0;

            // Assert
            Assert.Equal(expectedCount, actualCount);

        }
        [Fact]
        public void TestGetAllCars_WithoutTestData_ShouldGetAllCars()
        {
            // Arrange
            var contextFactory = new ApplicationDbContextFactory();
            var context = contextFactory.CreateApplicationDbContext();

            var mapperFactory = new AutoMapperFactory();
            var mapper = mapperFactory.CreateMapper();

            var carServices = new CarServices(context, mapper);

            // Act
            var actualCount = carServices.GetAllCars().Count;
            var expectedCount = 0;

            // Assert
            Assert.Equal(expectedCount, actualCount);

        }


        // Tests for Method: GetCarById(int CarId).
        [Fact]
        public void TestGetCarById_WithTestData_ShouldReturnTheCarWithId()
        {
            // Arrange
            var contextFactory = new ApplicationDbContextFactory();
            var context = contextFactory.CreateApplicationDbContext();

            var mapperFactory = new AutoMapperFactory();
            var mapper = mapperFactory.CreateMapper();

            var carServices = new CarServices(context, mapper);

            SeedDbWithCars(context);

            var car = context.Cars.FirstOrDefault();
            var carId = car.Id;

            // Act
            var expetedCar = car;
            var actualCar = carServices.GetCarById(carId);

            // Assert
            Assert.True(expetedCar.Id == actualCar.Id &&
                expetedCar.Brand == actualCar.Brand &&
                expetedCar.Model == actualCar.Model &&
                expetedCar.Number == actualCar.Number,
                "The Method: GetCarById() does not work correctly!");
        }


        // Tests for Method: GetCarById(int CarId).
        [Fact]
        public void TestGetCarById_WithoutTestData_ShouldReturnNull()
        {
            // Arrange
            var contextFactory = new ApplicationDbContextFactory();
            var context = contextFactory.CreateApplicationDbContext();

            var mapperFactory = new AutoMapperFactory();
            var mapper = mapperFactory.CreateMapper();

            var carServices = new CarServices(context, mapper);

            var carId = 1;

            // Act
            var actualCar = carServices.GetCarById(carId);

            // Assert
            Assert.True(null == actualCar,
                "The Method: GetCarById() does not work correctly!");
        }


        // Tests for Method: IsThereSuchCarWithNumber(string Number).
        [Fact]
        public void TestIsThereSuchCarWithNumber_WithTestData_ShouldReturnIsThereSuchCarWithNumberTrue()
        {
            // Arrange
            var contextFactory = new ApplicationDbContextFactory();
            var context = contextFactory.CreateApplicationDbContext();

            var mapperFactory = new AutoMapperFactory();
            var mapper = mapperFactory.CreateMapper();

            var carServices = new CarServices(context, mapper);

            SeedDbWithCars(context);

            var testNumber = "PB1234K";

            var isThreSuchCarWithNumber = carServices.IsThereSuchCarWithNumber(testNumber);

            var expectedResult = true;
            var actualResut = isThreSuchCarWithNumber;

            Assert.True(expectedResult == actualResut,
                "The method: IsThereSuchCarWithNumber(string number)(True) does not work correctly!");
        }
        [Fact]
        public void TestIsThereSuchCarWithNumber_WithTestData_ShouldReturnIsThereSuchCarWithNumberFalse()
        {
            // Arrange
            var contextFactory = new ApplicationDbContextFactory();
            var context = contextFactory.CreateApplicationDbContext();

            var mapperFactory = new AutoMapperFactory();
            var mapper = mapperFactory.CreateMapper();

            var carServices = new CarServices(context, mapper);

            SeedDbWithCars(context);

            var testNumber = "PB1234K1";

            var isThreSuchCarWithNumber = carServices.IsThereSuchCarWithNumber(testNumber);

            var expectedResult = false;
            var actualResut = isThreSuchCarWithNumber;

            Assert.True(expectedResult == actualResut,
                "The method: IsThereSuchCarWithNumber(string number)(False) does not work correctly!");

        }


        // Tests for Method: GetAllCarsForUserWithId(string userId).
        [Fact]
        public void TestGetAllCarsForUserWithId_WithTestData_ShouldReturnAllCarsForTheUserWithId()
        {
            // Arrange
            var contextFactory = new ApplicationDbContextFactory();
            var context = contextFactory.CreateApplicationDbContext();

            var mapperFactory = new AutoMapperFactory();
            var mapper = mapperFactory.CreateMapper();

            var carServices = new CarServices(context, mapper);


            SeedDbWithUsers(context);
            SeedDbWithCars(context);
            SeedCarsToTheFirstUser(context);

            var firstUser = context.Users.FirstOrDefault();

            // Act
            var count = carServices.GetAllCarsForUserWithId(firstUser.Id).Count();

            var expectedCount = 2;
            var actualCount = count;

            // Assert
            Assert.Equal(expected: expectedCount,actual: actualCount);

        }
        [Fact]
        public void TestGetAllCarsForUserWithId_WithUserIdNull_ShouldReturnZeroCarsForTheUserWithIdNull()
        {
            // Arrange
            var contextFactory = new ApplicationDbContextFactory();
            var context = contextFactory.CreateApplicationDbContext();

            var mapperFactory = new AutoMapperFactory();
            var mapper = mapperFactory.CreateMapper();

            var carServices = new CarServices(context, mapper);


            SeedDbWithUsers(context);
            SeedDbWithCars(context);
            SeedCarsToTheFirstUser(context);

            // Act
            var count = carServices.GetAllCarsForUserWithId(null).Count();

            var expectedCount = 0;
            var actualCount = count;

            // Assert
            Assert.Equal(expected: expectedCount, actual: actualCount);

        }
        [Fact]
        public void TestGetAllCarsForUserWithId_WithoutCarsForThisUser_ShouldReturnZeroCarsForTheUserWithIdNull()
        {
            // Arrange
            var contextFactory = new ApplicationDbContextFactory();
            var context = contextFactory.CreateApplicationDbContext();

            var mapperFactory = new AutoMapperFactory();
            var mapper = mapperFactory.CreateMapper();

            var carServices = new CarServices(context, mapper);


            SeedDbWithUsers(context);
            string userId = context.Users.FirstOrDefault().Id;

            // Act
            var count = carServices.GetAllCarsForUserWithId(userId).Count();

            var expectedCount = 0;
            var actualCount = count;

            // Assert
            Assert.Equal(expected: expectedCount, actual: actualCount);

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

        private IList<ApplicationUser> CreateUsers()
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
