using Microsoft.EntityFrameworkCore;
using StiveBack.Models;

namespace StiveBack.Database
{
    public class MainDbContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<UserRole> userRoles { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderProduct> orderproducts { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductCategory> productcategories { get; set; }
        public DbSet<PurchaseOrder> purchaseorders { get; set; }
        public DbSet<PurchaseOrderProduct> purchaseorderproducts { get; set; }
        public DbSet<Supplier> suppliers { get; set; }

        public MainDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
