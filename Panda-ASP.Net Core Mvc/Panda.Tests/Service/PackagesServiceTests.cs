using Microsoft.EntityFrameworkCore;
using Panda.Data;
using Panda.Domain;
using Panda.Services;
using Panda.Tests.Extensions;
using Panda.Tests.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Panda.Tests.Service
{
    public class PackagesServiceTests
    {

        

        [Fact]
        public void TestAddPackage_WithTestData_ShoudAddNewPackageInToDb()
        {
            var factory = new PandaDbContextFactory();
            var context = factory.CreatePandaDbContext();

            var services = new PackagesService(context);

            services.AddPackage(new Package());
            var packeges = context.Packages.ToList();

            var actualData = packeges.Count;
            var expectedData = 1;


            Assert.True(expectedData == actualData,
                "PackagesService AddPackage() method does not work porperly!");

        }
        [Fact]
        public void TestGetPackage_WithTestData_ShoudGetPackageWithId()
        {
            var factory = new PandaDbContextFactory();
            var context = factory.CreatePandaDbContext();
            var services = new PackagesService(context);

            SeedDbWithPackages(context);

            var package = context.Packages.FirstOrDefault();


            var actualData = services.GetPackage(package.Id);
            var expectedData = package;

            Assert.True(actualData.Id == expectedData.Id
                && actualData.Weight == expectedData.Weight
                && actualData.Description == expectedData.Description
                && actualData.ShippingAddress == expectedData.ShippingAddress);

        }
        [Fact]
        public void TestGetPackageStatus_WithTestData_ShoudGetPackageStatusWithName()
        {
            var factory = new PandaDbContextFactory();
            var context = factory.CreatePandaDbContext();
            var services = new PackagesService(context);

            SeedDbWithPackageStuses(context);

            var packageStatus = context.PackageStatus.FirstOrDefault();


            var actualData = services.GetPackageStatus(packageStatus.Name);
            var expectedData = packageStatus;

            Assert.True(actualData.Id == expectedData.Id
                && actualData.Name == expectedData.Name);

        }
        [Fact]
        public void TestGetPackagesWithRecipientAndStatus_WithTestData_ShoudGetAllPackagesWithRecipientAndStatus()
        {
            var factory = new PandaDbContextFactory();
            var context = factory.CreatePandaDbContext();
            var services = new PackagesService(context);

            SeedDbWithPackages(context);
            SeedDbWithPackageStuses(context);
            SeedDbWithRecipients(context);

            MakeTheConnectionBetweenTheEntities(context);

            var expectedData = context.Packages
                .Include(package => package.Recipient)
                .Include(package => package.Status)
                .ToList();

            var actualData = services.GetPackagesWithRecipientAndStatus().ToList();

            foreach (var package in actualData)
            {
                Assert.Contains(expectedData, x => x.Recipient.Id == package.Recipient.Id &&
                x.Status == package.Status);
               
            }


        }
        [Fact]
        public void TestUpdatePackage_WithTestData_ShoudUpdatePackage()
        {
            var factory = new PandaDbContextFactory();
            var context = factory.CreatePandaDbContext();

            var services = new PackagesService(context);
            double newWeight = 9999;

            SeedDbWithPackages(context);

            var package = context.Packages.FirstOrDefault();

            package.Weight = newWeight;
            services.UpdatePackage(package);


            var actualData = context.Packages.FirstOrDefault().Weight;
            var expectedData = newWeight;


            Assert.True(expectedData == actualData,
                "PackagesService UpdatePackage() method does not work porperly!");

        }

        private void SeedDbWithPackages(PandaDbContext context)
        {
            context.AddRange(CreatePacKages());
            context.SaveChanges();
        }
        private void SeedDbWithPackageStuses(PandaDbContext context)
        {
            context.PackageStatus.AddRange(CreatePacKageStatuses());
            context.SaveChanges();
        }
        private void SeedDbWithRecipients(PandaDbContext context)
        {
            context.Users.AddRange(CreateRecipients());
            context.SaveChanges();
        }
        private void MakeTheConnectionBetweenTheEntities(PandaDbContext context)
        {
            var packages = context.Packages.ToList();
            var packageStatuses = context.PackageStatus.ToList();
            var receipts = context.Users.ToList();

            for (int i = 0; i < 2; i++)
            {
                context.Packages.Update(packages[i]);
                packages[i].Recipient = receipts[i];
                packages[i].Status = packageStatuses[i];
            }

            context.SaveChanges();
        }

        private List<Package> CreatePacKages()
        {
            return new List<Package>()
            {
                new Package()
                {
                    Weight = 1040,
                    ShippingAddress = "first test Adress, 15",
                    Description = "first test description"
                },
                 new Package()
                {
                    Weight = 1020,
                    ShippingAddress = "second test Adress, 123",
                    Description = "second test description"
                }

            };
        }
        private List<PackageStatus> CreatePacKageStatuses()
        {
            return new List<PackageStatus>()
            {
               new PackageStatus()
               {
                   Name = "testStatus1"
               },
               new PackageStatus()
               {
                   Name = "testStatus2"
               }

            };
        }
        private List<PandaUser> CreateRecipients()
        {
            return new List<PandaUser>()
            {
                new PandaUser()
                {
                    UserName = "Test1",
                    Email = "test1@email.com"
                    
                },
                new PandaUser()
                {
                    UserName = "Test2",
                    Email = "test2@email.com"
                }
            };
        }



    }
}
