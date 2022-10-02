using FelipEcommerce.Application.ErrorHandler;
using FelipEcommerce.Persistence;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace FelipEcommerce.Application.Invoice
{
    public class EditInvoice
    {
        public class CommandEditInvoice : IRequest
        {
            public int Id { get; set; }
            public string InvoiceNumber { get; set; }
            public int? ClientId { get; set; }
            public int? UserId { get; set; }
            [Column(TypeName = "Date")] public DateTime? InvoiceDate { get; set; }
            public int? Isv { get; set; }
            public int? Discount { get; set; }
        }

        public class Handler : IRequestHandler<CommandEditInvoice>
        {
            private readonly FelipEcommerceContext _context;

            public Handler(FelipEcommerceContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CommandEditInvoice request, CancellationToken cancellationToken)
            {
                var invoice = await _context.Invoices.FindAsync(request.Id);

                if (invoice == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new { message = $"There is no invoice associated with the id {request.Id}" });

                if (await _context.Clients.FindAsync(request.ClientId) == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new
                        {
                            message =
                                $"There is no customer associated with the id {request.ClientId}. Please try again."
                        });

                if (await _context.Clients.FindAsync(request.UserId) == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new
                        {
                            message =
                                $"There is no user associated with the id {request.UserId}. Please try again."
                        });

                invoice.InvoiceNumber = request.InvoiceNumber ?? invoice.InvoiceNumber;
                invoice.ClientId = request.ClientId ?? invoice.ClientId;
                invoice.UserId = request.UserId ?? invoice.UserId;
                invoice.InvoiceDate = request.InvoiceDate ?? invoice.InvoiceDate;
                invoice.Discount = request.Discount ?? invoice.Discount;
                invoice.Isv = request.Isv ?? invoice.Isv;

                var value = await _context.SaveChangesAsync(cancellationToken);
                if (value > 0)
                    return Unit.Value;

                throw new Exception("The requested operation could not be performed.");
            }
        }
    }
}