using AutoMapper;
using FelipEcommerce.Persistence;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations.Schema;
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
            [Column(TypeName = "decimal(18,2)")] public decimal? Total { get; set; }
            [Column(TypeName = "decimal(18,2)")] public decimal? SubTotal { get; set; }
            public int? Isv { get; set; }
            public int? Discount { get; set; }
        }

        public class Handler : IRequestHandler<CommandEditInvoice>
        {
            private readonly FelipEcommerceContext _context;
            private readonly IMapper _mapper;

            public Handler(FelipEcommerceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(CommandEditInvoice request, CancellationToken cancellationToken)
            {
                var invoice = await _context.Invoices.FindAsync(request.Id);
                if (invoice == null)
                    throw new NotImplementedException();

                invoice.InvoiceNumber = request.InvoiceNumber ?? invoice.InvoiceNumber;
                invoice.ClientId = request.ClientId ?? invoice.ClientId;
                invoice.UserId = request.UserId ?? invoice.UserId;
                invoice.InvoiceDate = request.InvoiceDate ?? invoice.InvoiceDate;
                invoice.Total = request.Total ?? invoice.Total;
                invoice.SubTotal = request.SubTotal ?? invoice.SubTotal;
                invoice.Discount = request.Discount ?? invoice.Discount;
                invoice.Isv = request.Isv ?? invoice.Isv;

                var value = await _context.SaveChangesAsync(cancellationToken);
                if (value > 0)
                    return Unit.Value;

                throw new Exception("");
            }
        }
    }
}