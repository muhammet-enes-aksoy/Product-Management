
using Microsoft.EntityFrameworkCore;
using ProductManagement.Entities;

namespace ProductManagement.DbOperation;

public class DataGenerator
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context =
               new ProductManagementDbContext(serviceProvider
                   .GetRequiredService<DbContextOptions<ProductManagementDbContext>>()))
        {
            if (context.Products.Any())
            {
                return;
            }

            context.Products.AddRange(new Product()
                {
                    Name = "MSI Laptop",
                    CategoryId = 1,
                    Price = 2000
                    
                },
                new Product()
                {
                    Name = "MAC Lipgloss",
                    CategoryId = 2,
                    Price = 800
                }, new Product()
                {
                    Name = "Pant",
                    CategoryId = 3,
                    Price = 10
                });
            context.SaveChanges();
        }
    }
}