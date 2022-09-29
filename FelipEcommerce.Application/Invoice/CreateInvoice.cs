using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FelipEcommerce.Persistence;
using MediatR;

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
                var invoice = new Domain.Models.Invoice
                {
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

                throw new Exception("Error al crear la factura");
            }
        }
    }
}