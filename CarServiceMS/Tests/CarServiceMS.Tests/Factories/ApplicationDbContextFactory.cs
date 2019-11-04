using CarServiceMS.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace CarServiceMS.Tests.Factories
{



    public class ApplicationDbContextFactory
    {



        public ApplicationDbContext CreateApplicationDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: new Guid().ToString())
                .Options;

            var context = new ApplicationDbContext(options);

            return context;
        }
    }
}
