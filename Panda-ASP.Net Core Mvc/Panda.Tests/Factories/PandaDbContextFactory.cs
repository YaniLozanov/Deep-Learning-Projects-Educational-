using Microsoft.EntityFrameworkCore;
using Panda.Data;
using System;

namespace Panda.Tests.Factories
{
    public class PandaDbContextFactory
    {
        public PandaDbContext CreatePandaDbContext()
        {
            var options = new DbContextOptionsBuilder<PandaDbContext>()
                .UseInMemoryDatabase(databaseName: new Guid().ToString())
                .Options;

            var context = new PandaDbContext(options);

            return context;
        }
    }
}
