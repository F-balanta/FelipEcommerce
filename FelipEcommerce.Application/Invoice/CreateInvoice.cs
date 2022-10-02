using AutoMapper;
using FelipEcommerce.Application.ErrorHandler;
using FelipEcommerce.Helpers.Interfaces;
using FelipEcommerce.Persistence;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace FelipEcommerce.Application.Invoice
{
    public class CreateInvoice
    {
        public class CommandCreateInvoice : IRequest
        {
            public int ClientId { get; set; }
            public int UserId { get; set; }
            [Column(TypeName = "Date")] public DateTime InvoiceDate { get; set; }
            public int Isv { get; set; }
            public int Discount { get; set; }
        }

        public class Handler : IRequestHandler<CommandCreateInvoice>
        {
            private readonly FelipEcommerceContext _context;
            private readonly IMapper _mapper;
            private readonly IUtil _util;

            public Handler(FelipEcommerceContext context, IMapper mapper, IUtil util)
            {
                _context = context;
                _mapper = mapper;
                _util = util;
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

                if (await _context.Clients.FindAsync(request.UserId) == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new
                        {
                            message =
                                $"There is no user associated with the id {request.UserId}. Please try again."
                        });

                var invoice = new Domain.Models.Invoice
                {
                    InvoiceNumber = _util.GenerateInvoiceNumber(),
                    ClientId = request.ClientId,
                    UserId = request.UserId,
                    InvoiceDate = request.InvoiceDate,
                    Total = 0,
                    SubTotal = 0,
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