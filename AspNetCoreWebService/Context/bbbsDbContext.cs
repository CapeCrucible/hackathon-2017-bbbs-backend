using AspNetCoreWebService.Context.Models;
using Microsoft.EntityFrameworkCore;


namespace AspNetCoreWebService.Context
{
    public class bbbsDbContext : DbContext
    {
        public bbbsDbContext(DbContextOptions<bbbsDbContext> options)
            : base(options) { }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<ContactInfo> ContactInfo { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<InterestUserMap> InterestUserMaps { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
    }
}
