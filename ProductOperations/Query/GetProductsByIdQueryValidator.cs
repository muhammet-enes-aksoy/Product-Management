using FluentValidation;

namespace ProductManagement.ProductOperations.Query;

public class GetProductsByIdQueryValidator : AbstractValidator<GetProductsByIdQuery>
{
    public GetProductsByIdQueryValidator()
    {
        RuleFor(x => x.ProductId).GreaterThan(0);
    }
}