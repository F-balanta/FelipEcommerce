using FluentValidation;

namespace FelipEcommerce.Application.InvoiceDetail
{
    public class InvoiceDetailValidations
    {
        private const string NotEmpty = "must not be empty.";

        public class CreateInvoiceDetailCommandValidator : AbstractValidator<CreateDetail.CommandCreateInvoiceDetail>
        {
            public CreateInvoiceDetailCommandValidator()
            {
                RuleFor(x => x.ProductId).NotEmpty().WithMessage($"Product id {NotEmpty}");
                RuleFor(x => x.InvoiceId).NotEmpty().WithMessage($"Invoice id {NotEmpty}");
                RuleFor(x => x.Qty).NotEmpty().WithMessage($"Invoice id {NotEmpty}");

                RuleFor(x => x).Must(x => x.Qty > 0).WithMessage($"The number of products cannot be zero")
                    .OverridePropertyName("Qty");
            }
        }

        public class UpdateInvoiceDetailCommandValidator : AbstractValidator<CreateDetail.CommandCreateInvoiceDetail>
        {
            public UpdateInvoiceDetailCommandValidator()
            {
                RuleFor(x => x).Must(x => x.Qty > 0).WithMessage($"The number of products cannot be zero")
                    .OverridePropertyName("Qty");
            }
        }
    }
}