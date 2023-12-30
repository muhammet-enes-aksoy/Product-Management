using FluentValidation;

namespace ProductManagement.ProductOperations.Command.DeleteProduct;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.ProductId).GreaterThan(0);
    }
}