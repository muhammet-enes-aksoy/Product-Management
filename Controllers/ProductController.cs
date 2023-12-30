using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using ProductManagement.DbOperation;
using ProductManagement.ProductOperations.Command.DeleteProduct;
using ProductManagement.ProductOperations.Command.CreateProduct;
using ProductManagement.ProductOperations.Query;
using ProductManagement.ProductOperations.Command.UpdateProduct;
using ProductManagement.ProductOperations.Command.PatchProduct;
using Customer_management.CustomerOperations.Command.PatchCustomer;

namespace ProductManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductManagementDbContext _context;
        private readonly IMapper _mapper;

        public ProductController(ProductManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ProductsViewModel> Get()
        {
            GetProductsQuery query = new GetProductsQuery(_context, _mapper);
            var productList = query.Handle();
            return productList;
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            GetProductsByIdQuery query = new GetProductsByIdQuery(_context, _mapper);

            query.ProductId = id;

            GetProductsByIdQueryValidator validator = new GetProductsByIdQueryValidator();
            validator.ValidateAndThrow(query);

            var customer = query.Handle();

            return Ok(customer);
        }


         // PUT: api/Customer/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProductModel updateProduct)
        {
            var command = new UpdateProductCommand(_context, _mapper)
            {
                Model = updateProduct,
                ProductId = id
            };
            var validator = new UpdateProductCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }
        // POST: api/Customer
        [HttpPost]
        public IActionResult Post([FromBody] CreateProductModel model)
        {
            var command = new CreateProductCommand(_context, _mapper)
            {
                Model = model
            };
            var validator = new CreateProductCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }
        // PATCH: api/Customer/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<UpdateProductModel> patchDoc)
        {
            var command = new PatchProductCommand(_context, _mapper)
            {
                ProductId = id
            };
            var validator = new PatchProductCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var command = new DeleteProductCommand(_context)
            {
                ProductId = id
            };
            var validator = new DeleteProductCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }
    }
}