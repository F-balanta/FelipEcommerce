using AutoMapper;
using FelipEcommerce.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using FelipEcommerce.Helpers;
using FluentValidation;

namespace FelipEcommerce.Application.Client
{
    public class CreateClient
    {
        public class CommandCreateClient : IRequest
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Phone { get; set; }
            public string Dni { get; set; }
            public string Address { get; set; }
            public int Age { get; set; }
        }

        public class CommandValidator : AbstractValidator<CommandCreateClient>
        {
            public CommandValidator()
            {
                RuleFor(x => x.FirstName).Must(ValidatorsMethods.IsStringApiDefault).WithMessage("El campo es nulo");
                RuleFor(x => x.LastName).Must(ValidatorsMethods.IsStringApiDefault).WithMessage("El campo es nulo");
                RuleFor(x => x.Phone).Must(ValidatorsMethods.IsStringApiDefault).WithMessage("El campo es nulo");
                RuleFor(x => x.Dni).Must(ValidatorsMethods.IsStringApiDefault).WithMessage("El campo es nulo");
                RuleFor(x => x.Address).Must(ValidatorsMethods.IsStringApiDefault).WithMessage("El campo es nulo");
            }
        }

        public class Handler : IRequestHandler<CommandCreateClient>
        {
            private readonly FelipEcommerceContext _context;

            public Handler(FelipEcommerceContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CommandCreateClient request, CancellationToken cancellationToken)
            {
                var client = new Domain.Models.Client
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Phone = request.Phone,
                    Dni = request.Dni,
                    Address = request.Address,
                    Age = request.Age
                };

                _context.Clients.Add(client);

                var value = await _context.SaveChangesAsync(cancellationToken);

                if (value > 0)
                    return Unit.Value;

                throw new Exception("The requested operation could not be performed.");
            }
        }
    }
}