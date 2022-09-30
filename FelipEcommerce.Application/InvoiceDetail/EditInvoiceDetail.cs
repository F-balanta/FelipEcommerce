using AutoMapper;
using FelipEcommerce.Persistence;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FelipEcommerce.Application.ErrorHandler;
using Microsoft.EntityFrameworkCore;

namespace FelipEcommerce.Application.InvoiceDetail
{
    public class EditInvoiceDetail
    {
        public class CommandEditInvoiceDetail : IRequest
        {
            public int Id { get; set; }
            public int? ProductId { get; set; }
            public int? Qty { get; set; }
            public int? InvoiceId { get; set; }
            [Column(TypeName = "decimal(18,2)")] public decimal? Price { get; set; }
        }

        public class Handler : IRequestHandler<CommandEditInvoiceDetail>
        {
            private readonly FelipEcommerceContext _context;
            private readonly IMapper _mapper;

            public Handler(FelipEcommerceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(CommandEditInvoiceDetail request, CancellationToken cancellationToken)
            {
                var invoiceDetail = await _context.InvoicesDetail.FindAsync(request.Id);
                if (invoiceDetail == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new { message = $"There is no detailed invoice record associated with the id {request.Id}. Please try again." });

                invoiceDetail.ProductId = request.ProductId ?? invoiceDetail.ProductId;
                invoiceDetail.Qty = request.Qty ?? invoiceDetail.Qty;
                invoiceDetail.InvoiceId = request.InvoiceId ?? invoiceDetail.InvoiceId;
                invoiceDetail.Price = request.Price ?? invoiceDetail.Price;

                var value = await _context.SaveChangesAsync(cancellationToken);
                if (value > 0)
                    return Unit.Value;

                throw new Exception("The requested operation could not be performed.");
            }
        }
    }
}