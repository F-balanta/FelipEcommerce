using FluentValidation;

namespace FelipEcommerce.Application.Inventory
{
    public class InventoryValidations
    {
        public class CreateInventoryCommandValidator : AbstractValidator<NewInventory.CommandInventory>
        {
            public CreateInventoryCommandValidator()
            {
                RuleFor(x => x.InventoryDate).NotEmpty();
                RuleFor(x => x.Qty).NotEmpty();
            }
        }
    }
}