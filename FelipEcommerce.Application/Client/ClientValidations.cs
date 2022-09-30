using FluentValidation;

namespace FelipEcommerce.Application.Client
{
    public class ClientValidations
    {
        private const string NotEmpty = "must not be empty.";

        public class CreateClientCommandValidator : AbstractValidator<CreateClient.CommandCreateClient>
        {
            public CreateClientCommandValidator()
            {
                RuleFor(x => x.FirstName).NotEmpty().WithMessage($"The First Name {NotEmpty}");
                RuleFor(x => x.LastName).NotEmpty().WithMessage($"The Last Name {NotEmpty}");
                RuleFor(x => x.Address).NotEmpty().WithMessage($"The Address must {NotEmpty}");
                RuleFor(x => x.Dni).NotEmpty().WithMessage($"The DNI must {NotEmpty}");
                RuleFor(x => x.Phone).NotEmpty().WithMessage($"The Phone must {NotEmpty}");
                RuleFor(x => x.Age).NotEmpty().WithMessage($"The Age must {NotEmpty}");

                RuleFor(x => x).Must(x => x.FirstName != "string").WithMessage($"The First Name must {NotEmpty}")
                    .OverridePropertyName("FirstName");
                RuleFor(x => x).Must(x => x.LastName != "string").WithMessage($"The Last Name must {NotEmpty}")
                    .OverridePropertyName("LastName");
                RuleFor(x => x).Must(x => x.Address != "string").WithMessage($"The Address must {NotEmpty}")
                    .OverridePropertyName("Address");
                RuleFor(x => x).Must(x => x.Dni != "string").WithMessage($"The Dni must {NotEmpty}")
                    .OverridePropertyName("Dni");
                RuleFor(x => x).Must(x => x.Phone != "string").WithMessage($"The Phone must {NotEmpty}")
                    .OverridePropertyName("Phone");
            }
        }

        public class UpdateClientCommandValidator : AbstractValidator<EditClient.CommandEditClient>
        {
            public UpdateClientCommandValidator()
            {
                RuleFor(x => x).Must(x => x.FirstName != "string").WithMessage($"The First Name must {NotEmpty}")
                    .OverridePropertyName("FirstName");
                RuleFor(x => x).Must(x => x.LastName != "string").WithMessage($"The Last Name must {NotEmpty}")
                    .OverridePropertyName("LastName");
                RuleFor(x => x).Must(x => x.Address != "string").WithMessage($"The Address must {NotEmpty}")
                    .OverridePropertyName("Address");
                RuleFor(x => x).Must(x => x.Dni != "string").WithMessage($"The Dni must {NotEmpty}")
                    .OverridePropertyName("Dni");
                RuleFor(x => x).Must(x => x.Phone != "string").WithMessage($"The Phone must {NotEmpty}")
                    .OverridePropertyName("Phone");
            }
        }
    }
}