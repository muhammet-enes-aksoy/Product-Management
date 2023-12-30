using AutoMapper;
using ProductManagement.Common;
using ProductManagement.DbOperation;

namespace ProductManagement.ProductOperations.Command.UpdateProduct;

public class UpdateProductCommand
{
    private readonly ProductManagementDbContext _context;
    private readonly IMapper _mapper;
    public UpdateProductModel Model { get; set; }  
    public int ProductId { get; set; }

    public UpdateProductCommand(ProductManagementDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Handle()
    {
        var product = _context.Products.Find(ProductId);
        if (product is null)
        {
            throw new InvalidOperationException("Product not found");
        }

        product.Name = Model.Name != default ? Model.Name : product.Name;
        product.CategoryId = Model.CategoryId != default ? Model.CategoryId : product.CategoryId;
        product.Price = Model.Price != default ? Model.Price : product.Price;
        _context.SaveChanges();
    }
}

public class UpdateProductModel
{
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public int Price { get; set; }
}