using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Morgenmadsbuffeten.Data.DBModels;

namespace Morgenmadsbuffeten.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CheckedIn> CheckedIns { get; set; }
        public DbSet<ExpectedGuests> ExpectedGuests { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);

            mb.Entity<CheckedIn>().HasKey(p => new {p.RoomNumber, p.Date});
            mb.Entity<ExpectedGuests>().HasKey(p => p.Date);
        }
    }
}
