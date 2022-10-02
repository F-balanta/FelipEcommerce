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
                RuleFor(x => x.ClientId).NotEmpty().WithMessage($"Customer id {NotEmpty}");
                RuleFor(x => x.UserId).NotEmpty().WithMessage($"User id {NotEmpty}");
                RuleFor(x => x.InvoiceDate).NotEmpty().WithMessage($"Invoice date {NotEmpty}");
                RuleFor(x => x.Isv).NotEmpty().WithMessage($"Isv {NotEmpty}");
                RuleFor(x => x.Discount).NotEmpty().WithMessage($"Discount {NotEmpty}");

                RuleFor(x => x).Must(x => x.ClientId > 0).WithMessage($"Customer {NotZero}")
                    .OverridePropertyName("ClientId");

                RuleFor(x => x).Must(x => x.UserId > 0).WithMessage($"User id {NotZero}")
                    .OverridePropertyName("UserId");

                RuleFor(x => x).Must(x => x.Isv > 0).WithMessage($"Isv {NotZero}")
                    .OverridePropertyName("Isv");
            }
        }

        public class UpdateInvoiceValidator : AbstractValidator<CreateInvoice.CommandCreateInvoice>
        {
            public UpdateInvoiceValidator()
            {
                RuleFor(x => x.InvoiceDate).NotEmpty().WithMessage($"Invoice date {NotEmpty}");
                RuleFor(x => x.Isv).NotEmpty().WithMessage($"Isv {NotEmpty}");
                RuleFor(x => x.Discount).NotEmpty().WithMessage($"Discount {NotEmpty}");

                RuleFor(x => x).Must(x => x.Isv > 0).WithMessage($"Isv {NotZero}")
                    .OverridePropertyName("Isv");
            }
        }
    }
}