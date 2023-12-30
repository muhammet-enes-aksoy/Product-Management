using Microsoft.EntityFrameworkCore;
using ProductManagement.Entities;

namespace ProductManagement.DbOperation;

public class ProductManagementDbContext : DbContext
{
    public ProductManagementDbContext(DbContextOptions<ProductManagementDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}