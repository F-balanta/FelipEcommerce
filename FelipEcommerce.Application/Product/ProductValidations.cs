using FluentValidation;

namespace FelipEcommerce.Application.Product
{
    public class ProductValidations
    {
        private const string NotEmpty = "must not be empty.";

        public class CreateProductValidator : AbstractValidator<CreateProduct.CommandCreateProduct>
        {
            public CreateProductValidator()
            {
                RuleFor(x => x.Name).NotEmpty().WithMessage($"Product name {NotEmpty}");
                RuleFor(x => x.Description).NotEmpty().WithMessage($"Product description {NotEmpty}");
                RuleFor(x => x.UrlImage).NotEmpty().WithMessage($"Product image url {NotEmpty}");
                RuleFor(x => x.Price).NotEmpty().WithMessage($"Product price {NotEmpty}");

                RuleFor(x => x).Must(x => x.Name != "string").WithMessage($"Product name  {NotEmpty}")
                    .OverridePropertyName("Name");

                RuleFor(x => x).Must(x => x.Description != "string").WithMessage($"Product description {NotEmpty}")
                    .OverridePropertyName("Description");

                RuleFor(x => x).Must(x => x.UrlImage != "string").WithMessage($"Product image url {NotEmpty}")
                    .OverridePropertyName("UrlImage");

                RuleFor(x => x).Must(x => x.Price > 0).WithMessage($"Product price cannot be zero.")
                    .OverridePropertyName("Price");
            }
        }

        public class UpdateProductValidator : AbstractValidator<EditProduct.CommandEditProduct>
        {
            public UpdateProductValidator()
            {
                RuleFor(x => x).Must(x => x.Name != "string").WithMessage($"Product name {NotEmpty}")
                    .OverridePropertyName("Name");

                RuleFor(x => x).Must(x => x.Price > 0).WithMessage($"Product price cannot be zero.")
                    .OverridePropertyName("Price");
            }
        }
    }
}