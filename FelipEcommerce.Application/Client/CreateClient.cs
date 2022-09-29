using AutoMapper;
using FelipEcommerce.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

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

        public class Handler : IRequestHandler<CommandCreateClient>
        {
            private readonly FelipEcommerceContext _context;
            private readonly IMapper _mapper;

            public Handler(FelipEcommerceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
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

                throw new Exception("Cambios no guardados");
            }
        }
    }
}