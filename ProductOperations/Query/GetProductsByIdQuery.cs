using AutoMapper;
using ProductManagement.Common;
using ProductManagement.DbOperation;

namespace ProductManagement.ProductOperations.Query;

public class GetProductsByIdQuery
{
    private readonly ProductManagementDbContext _context;
    private readonly IMapper _mapper;

    public int ProductId { get; set; }

    public GetProductsByIdQuery(ProductManagementDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public GetProductViewModel Handle()
    {
        var product = _context.Products.SingleOrDefault(x => x.Id == ProductId);
        if (product is null)
        {
            throw new InvalidOperationException("Product not found");
        }

        var model= _mapper.Map<GetProductViewModel>(product);
        return model;
    }
}

public class GetProductViewModel
{
    public string Name { get; set; }
    public string Category { get; set; }
    public int Price { get; set; }
}