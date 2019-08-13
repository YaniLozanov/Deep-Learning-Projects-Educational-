using Eventures.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Eventures.Data
{
    public class EventuresDbContext : IdentityDbContext<EventuresUser, IdentityRole, string>
    {

        public EventuresDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
