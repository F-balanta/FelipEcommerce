using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FelipEcommerce.Application.ErrorHandler;
using FelipEcommerce.Persistence;
using MediatR;

namespace FelipEcommerce.Application.Invoice
{
    public class DeleteInvoice
    {
        public class CommandDeleteInvoice : IRequest
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<CommandDeleteInvoice>
        {
            private readonly FelipEcommerceContext _context;

            public Handler(FelipEcommerceContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CommandDeleteInvoice request, CancellationToken cancellationToken)
            {
                var invoice = await _context.Invoices.FindAsync(request.Id);
                if (invoice == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new { message = $"There is no invoice associated with the id {request.Id}" });

                _context.Invoices.Remove(invoice);

                var value = await _context.SaveChangesAsync(cancellationToken);

                if (value > 0)
                    return Unit.Value;

                throw new Exception("The requested operation could not be performed.");
            }
        }
    }
}