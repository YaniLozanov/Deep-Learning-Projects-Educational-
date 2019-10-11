using Microsoft.EntityFrameworkCore;
using Panda.Data;
using Panda.Domain;
using Panda.Services;
using Panda.Tests.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Panda.Tests.Service
{
    public class ReceiptsServiceTests
    {
        [Fact]
        public void TestAddReceipt_WithTestData_ShoudAddNewPackageInToDb()
        {
            var factory = new PandaDbContextFactory();
            var context = factory.CreatePandaDbContext();
            var services = new ReceiptsService(context);

            services.AddReceipt(new Receipt());


            var actualData = context.Receipts.Count();

            Assert.True(actualData == 1, "PackagesService AddPackage() method does not work porperly!");
        }

        [Fact]
        public void TestGetAllReceiptsWithRecipient_WithTestData_ShoudGetAllReceiptsWithRecipient()
        {
            var factory = new PandaDbContextFactory();
            var context = factory.CreatePandaDbContext();
            var services = new ReceiptsService(context);

            SeedDbWithReceipts(context);
            SeedDbWithRecipients(context);
            MakeConnectionBetweenTheEntities(context);

            var actualData = services.GetAllReceiptsWithRecipient().ToList();
            var expectedData = context.Receipts
                .Include(receipt => receipt.Recipient)
                .ToList();

            foreach (var receipt in expectedData)
            {
                Assert.Contains(actualData, x =>
                x.Recipient.UserName == receipt.Recipient.UserName &&
                x.Recipient.Email == x.Recipient.Email);
            }

        }

        [Fact]
        public void GetAllReceiptsWithRecipientAndPackage_WithTestData_ShoudGetAllReceiptsWithRecipientAndPackage()
        {
            var factory = new PandaDbContextFactory();
            var context = factory.CreatePandaDbContext();
            var services = new ReceiptsService(context);

            var expectedData = context.Receipts
                .Include(receipt => receipt.Package)
                .Include(receipt => receipt.Recipient)
                .ToList();

            var actualData = services.GetAllReceiptsWithRecipientAndPackage();


            foreach (var receipt in actualData)
            {
                Assert.Contains(expectedData, x => x.Package.Id == receipt.Package.Id 
                && x.Recipient.Id == receipt.Recipient.Id);
            }
        }

        private void SeedDbWithReceipts(PandaDbContext context)
        {
            context.Receipts.AddRange(CreateReceipts());
            context.SaveChanges();
        }
        private void SeedDbWithRecipients(PandaDbContext context)
        {
            context.Users.AddRange(CreateRecipients());
            context.SaveChanges();
        }
        private void SeedDbWithPackages(PandaDbContext context)
        {
            context.Packages.AddRange(CreatePackages());
            context.SaveChanges();
        }
        private void MakeConnectionBetweenTheEntities(PandaDbContext context)
        {
            var receipts = context.Receipts.ToList();
            var recipients = context.Users.ToList();
            var packages = context.Packages.ToList();

            for (int i = 0; i < 2; i++)
            {
                context.Receipts.Update(receipts[i]);
                receipts[i].Recipient = recipients[i];
                receipts[i].Package = packages[i];

            }

            context.SaveChanges();
        }

        private List<Receipt> CreateReceipts()
        {
            return new List<Receipt>()
            {
                new Receipt()
                {
                   Fee = 123,
                    
                },
                new Receipt()
                {
                   Fee = 1000,

                }
            };
        }
        private List<PandaUser> CreateRecipients()
        {
            return new List<PandaUser>()
            {
                new PandaUser()
                {
                   UserName = "TestUser1",
                   Email = "test1@email.com"

                },
                new PandaUser()
                {
                   UserName = "TestUser2",
                   Email = "test2@email.com"
                }
            };
        }
        private List<Package> CreatePackages()
        {
            return new List<Package>()
            {
                new Package()
                {
                   Weight = 9999,
                   ShippingAddress = "Test Address 1",
                   Description = "That is test 1 description"

                },
                new Package()
                {
                   Weight = 10000,
                   ShippingAddress = "Test Address2",
                   Description = "That is test 2 description"

                }
            };
        }


    }
}
