using FluentValidation;

namespace FelipEcommerce.Application.Invoice
{
    public class InvoiceValidations
    {
        private const string NotEmpty = "must not be empty.";
        private const string NotZero = "cannot be zero.";

        public class CreateInvoiceValidator : AbstractValidator<CreateInvoice.CommandCreateInvoice>
        {
            public CreateInvoiceValidator()
            {
                RuleFor(x => x.InvoiceNumber).NotEmpty().WithMessage($"Invoice Number {NotEmpty}");
                RuleFor(x => x.ClientId).NotEmpty().WithMessage($"Customer id {NotEmpty}");
                RuleFor(x => x.UserId).NotEmpty().WithMessage($"User id {NotEmpty}");
                RuleFor(x => x.InvoiceDate).NotEmpty().WithMessage($"Invoice date {NotEmpty}");
                RuleFor(x => x.SubTotal).NotEmpty().WithMessage($"SubTotal {NotEmpty}");
                RuleFor(x => x.Total).NotEmpty().WithMessage($"Total {NotEmpty}");
                RuleFor(x => x.Isv).NotEmpty().WithMessage($"Isv {NotEmpty}");
                RuleFor(x => x.Discount).NotEmpty().WithMessage($"Discount {NotEmpty}");

                RuleFor(x => x).Must(x => x.SubTotal > 0).WithMessage($"Invoice number {NotEmpty}")
                    .OverridePropertyName("InvoiceNumber");

                RuleFor(x => x).Must(x => x.Total > 0).WithMessage($"Total {NotZero}")
                    .OverridePropertyName("Total");

                RuleFor(x => x).Must(x => x.ClientId > 0).WithMessage($"Customer {NotZero}")
                    .OverridePropertyName("Total");

                RuleFor(x => x).Must(x => x.UserId > 0).WithMessage($"User id {NotZero}")
                    .OverridePropertyName("Total");

                RuleFor(x => x).Must(x => x.InvoiceNumber != "string").WithMessage($"Invoice number {NotEmpty}")
                    .OverridePropertyName("InvoiceNumber");
            }
        }

        public class UpdateInvoiceValidator : AbstractValidator<CreateInvoice.CommandCreateInvoice>
        {
            public UpdateInvoiceValidator()
            {
                RuleFor(x => x).Must(x => x.SubTotal > 0).WithMessage($"Subtotal {NotZero}")
                    .OverridePropertyName("SubTotal");

                RuleFor(x => x).Must(x => x.Total > 0).WithMessage($"Total {NotZero}")
                    .OverridePropertyName("Total");

                RuleFor(x => x).Must(x => x.InvoiceNumber != "string").WithMessage($"Invoice number {NotEmpty}")
                    .OverridePropertyName("InvoiceNumber");
            }
        }
    }
}