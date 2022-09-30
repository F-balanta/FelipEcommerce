using FelipEcommerce.Persistence;
using MediatR;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FelipEcommerce.Application.ErrorHandler;

namespace FelipEcommerce.Application.Client
{
    public class DeleteClient
    {
        public class CommandDeleteClient : IRequest
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<CommandDeleteClient>
        {
            private readonly FelipEcommerceContext _context;

            public Handler(FelipEcommerceContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CommandDeleteClient request, CancellationToken cancellationToken)
            {
                var client = await _context.Clients.FindAsync(request.Id);
                if (client == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new
                        {
                            message = $"There is no customer associated with the id {request.Id}. Please try again."
                        });


                _context.Remove(client);
                var value = await _context.SaveChangesAsync(cancellationToken);
                if (value > 0)
                    return Unit.Value;
                throw new Exception("The requested operation could not be performed.");
            }
        }
    }
}