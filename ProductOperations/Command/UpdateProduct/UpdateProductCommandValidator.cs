using FluentValidation;

namespace ProductManagement.ProductOperations.Command.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        
    }
}