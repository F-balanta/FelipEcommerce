using FluentValidation;

namespace FelipEcommerce.Application.Inventory
{
    public class InventoryValidations
    {
        public class CreateInventoryCommandValidator : AbstractValidator<NewInventory.CommandInventory>
        {
            public CreateInventoryCommandValidator()
            {
                RuleFor(x => x.InventoryDate).NotEmpty().WithMessage("The inventory date must not be empty");
                RuleFor(x => x.Qty).NotEmpty().WithMessage("The quantity must not be empty");
            }
        }
    }
}