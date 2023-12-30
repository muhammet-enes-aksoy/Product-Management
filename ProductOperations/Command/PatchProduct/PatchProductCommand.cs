using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using ProductManagement.DbOperation;

namespace ProductManagement.ProductOperations.Command.PatchProduct;

public class PatchProductCommand
{
    private readonly ProductManagementDbContext _context;
    private readonly IMapper _mapper;
    public JsonPatchDocument<PatchProductModel> PatchDocument { get; set; }
    public int ProductId { get; set; }

    public PatchProductCommand(ProductManagementDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Handle()
    {
        var product = _context.Products.SingleOrDefault(x => x.Id == ProductId);
        if (product is null)
        {
            throw new InvalidOperationException("Product not found");
        }

        var productModel = _mapper.Map<PatchProductModel>(product);
        var jobOperation = PatchDocument.Operations.SingleOrDefault(x => x.path == "/price");
        if (jobOperation != null)
        {
            productModel.Price = (int)jobOperation.value;
        }
        else if (jobOperation.OperationType==OperationType.Remove)
        {
            productModel.Price = 0;
        }
        
        _mapper.Map(productModel, product);
        _context.SaveChanges();
    }
}

public class PatchProductModel
{
    public int Price { get; set; }
}