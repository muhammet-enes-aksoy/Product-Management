using AutoMapper;
using ProductManagement.Common;
using ProductManagement.DbOperation;

namespace ProductManagement.ProductOperations.Query;

public class GetProductsQuery
{
    private readonly ProductManagementDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetProductsQuery(ProductManagementDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public IEnumerable<ProductsViewModel> Handle()
    {
        var productList = _dbContext.Products.OrderBy(x => x.Id).ToList();
        var vm = _mapper.Map<List<ProductsViewModel>>(productList);
        return vm;
    }
}

public class ProductsViewModel
{
    public string Name { get; set; }
    public string Category { get; set; }
    public int Price { get; set; }
    
}