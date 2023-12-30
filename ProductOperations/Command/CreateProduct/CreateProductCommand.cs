using AutoMapper;
using ProductManagement.Common;
using ProductManagement.DbOperation;
using ProductManagement.Entities;


namespace ProductManagement.ProductOperations.Command.CreateProduct;

public class CreateProductCommand
{
    private readonly ProductManagementDbContext _context;
    private readonly IMapper _mapper;
    public CreateProductModel Model { get; set; }

    public CreateProductCommand(ProductManagementDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Handle()
    {
        var product = _context.Products.SingleOrDefault(x => x.Name == Model.Name);
        if (product is not null)
        {
            throw new InvalidOperationException("Product already exists");
        }

        product = _mapper.Map<Product>(Model);
        _context.Products.Add(product);
        _context.SaveChanges();
    }
}

public class CreateProductModel
{
    public string Name { get; set; } = ""; 
    public int Category { get; set; }
    public int Price { get; set; }
}