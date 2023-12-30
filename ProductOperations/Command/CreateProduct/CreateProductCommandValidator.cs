using FluentValidation;

namespace ProductManagement.ProductOperations.Command.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Model.Name).NotEmpty().MinimumLength(3);
        RuleFor(x => x.Model.Price).NotEmpty().GreaterThan(0);
    }
}