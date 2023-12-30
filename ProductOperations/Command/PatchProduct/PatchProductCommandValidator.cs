using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;
using ProductManagement.ProductOperations.Command.PatchProduct;

namespace Customer_management.CustomerOperations.Command.PatchCustomer;

public class PatchProductCommandValidator : AbstractValidator<PatchProductCommand>
{
    public PatchProductCommandValidator()
    {
        RuleFor(x => x.ProductId).GreaterThan(0);
        RuleFor(x => x.PatchDocument).Must(ContainOnlyJobOperation)
            .WithMessage("Only 'Price' can be updated.");
    }

    private bool ContainOnlyJobOperation(JsonPatchDocument<PatchProductModel> patchDoc)
    {
        if (patchDoc != null && patchDoc.Operations.Count == 1)
        {
            var operation = patchDoc.Operations[0];
            return operation.path == "/price";
        }

        return false;
    }
}