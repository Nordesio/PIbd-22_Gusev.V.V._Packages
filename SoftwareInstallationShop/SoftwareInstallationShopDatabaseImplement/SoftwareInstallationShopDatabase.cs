using SoftwareInstallationShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace SoftwareInstallationShopDatabaseImplement
{
    public class SoftwareInstallationShopDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=HOME\SQLEXPRESS;Initial
Catalog=AbstractShopDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Component> Components { set; get; }
        public virtual DbSet<Package> Packages { set; get; }
        public virtual DbSet<ProductComponent> ProductComponents { set; get; }
        public virtual DbSet<Order> Orders { set; get; }

    }
}
