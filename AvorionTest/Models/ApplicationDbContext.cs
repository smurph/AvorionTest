using System.Data.Entity;
using AvorionTest.Models.Database;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AvorionTest.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("AvorionConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<TradeGood> TradeGoods { get; set; }

        public DbSet<Station> Stations { get; set; }

        public DbSet<TradeRecord> TradeRecords { get; set; }
    }
}