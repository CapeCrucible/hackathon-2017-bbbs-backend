using AspNetCoreWebService.Context.Models;
using Microsoft.EntityFrameworkCore;


namespace AspNetCoreWebService.Context
{
    public class bbbsDbContext : DbContext
    {
        public bbbsDbContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=ccbbbsdb.co1ic5cxttaa.us-east-1.rds.amazonaws.com;Initial Catalog=bbbs2017db;Persist Security Info=True;User ID=bbbsuser;Password=1bbbsHackathon!");
        }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<ContactInfo> ContactInfo { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<InterestUserMap> InterestUserMaps { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<LittleParentMap> LittleParentMaps { get; set; }
        public DbSet<BigLittleParentMap> BigLittleParentMaps { get; set; }
    }
}
