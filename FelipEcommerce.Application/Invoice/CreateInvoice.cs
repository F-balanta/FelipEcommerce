using AutoMapper;
using FelipEcommerce.Persistence;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FelipEcommerce.Application.ErrorHandler;

namespace FelipEcommerce.Application.Invoice
{
    public class CreateInvoice
    {
        public class CommandCreateInvoice : IRequest
        {
            public string InvoiceNumber { get; set; }
            public int ClientId { get; set; }
            public int UserId { get; set; }

            [Column(TypeName = "Date")] public DateTime InvoiceDate { get; set; }
            [Column(TypeName = "decimal(18,2)")] public decimal Total { get; set; }
            [Column(TypeName = "decimal(18,2)")] public decimal SubTotal { get; set; }
            public int Isv { get; set; }
            public int Discount { get; set; }
        }

        public class Handler : IRequestHandler<CommandCreateInvoice>
        {
            private readonly FelipEcommerceContext _context;
            private readonly IMapper _mapper;

            public Handler(FelipEcommerceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(CommandCreateInvoice request, CancellationToken cancellationToken)
            {
                if (await _context.Clients.FindAsync(request.ClientId) == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new
                        {
                            message =
                                $"There is no customer associated with the id {request.ClientId}. Please try again."
                        });

                if(await _context.Clients.FindAsync(request.UserId) == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new
                        {
                            message =
                                $"There is no user associated with the id {request.UserId}. Please try again."
                        });

                var invoice = new Domain.Models.Invoice
                {
                    InvoiceNumber = request.InvoiceNumber,
                    ClientId = request.ClientId,
                    UserId = request.UserId,
                    InvoiceDate = request.InvoiceDate,
                    Total = request.Total,
                    SubTotal = request.SubTotal,
                    Isv = request.Isv,
                    Discount = request.Discount,
                };

                _context.Invoices.Add(invoice);

                var value = await _context.SaveChangesAsync(cancellationToken);

                if (value > 0)
                    return Unit.Value;

                throw new Exception("The requested operation could not be performed.");
            }
        }
    }
}