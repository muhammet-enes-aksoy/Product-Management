using ProductManagement.DbOperation;

namespace ProductManagement.ProductOperations.Command.DeleteProduct;

public class DeleteProductCommand
{
    private readonly ProductManagementDbContext _context;
    public int ProductId { get; set; }

    public DeleteProductCommand(ProductManagementDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var product = _context.Products.SingleOrDefault(x => x.Id == ProductId);
        if (product is null)
        {
            throw new InvalidOperationException("Product not found");
        }

        _context.Products.Remove(product);
        _context.SaveChanges();
    }
}