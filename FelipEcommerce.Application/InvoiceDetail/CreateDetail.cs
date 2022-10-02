using System;
using System.Linq;
using AutoMapper;
using FelipEcommerce.Application.ErrorHandler;
using FelipEcommerce.Helpers.Interfaces;
using FelipEcommerce.Persistence;
using MediatR;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FelipEcommerce.Application.InvoiceDetail
{
    public class CreateDetail
    {
        public class CommandCreateInvoiceDetail : IRequest
        {
            public int ProductId { get; set; }
            public int Qty { get; set; }
            public int InvoiceId { get; set; }
        }

        public class Handler : IRequestHandler<CommandCreateInvoiceDetail>
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

            public async Task<Unit> Handle(CommandCreateInvoiceDetail request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.FindAsync(request.ProductId);
                if (product == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new { message = $"There is no product with the id {request.ProductId}. Please try again" });

                var inventory = await _context.Inventory.FirstOrDefaultAsync(x => x.ProductId == product.Id,
                    cancellationToken: cancellationToken);

                if (inventory == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new { message = "The desired product is not in stock" });

                if (inventory.Qty < request.Qty)
                    throw new RestException(HttpStatusCode.BadRequest,
                        new { message = "The quantity of products desired exceeds the quantity available in stock." });

                var invoice = await _context.Invoices.FindAsync(request.InvoiceId);
                if (invoice == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new { message = $"There is no invoice associated with the id {request.InvoiceId}" });

                var invoiceDetail = new Domain.Models.InvoiceDetail
                {
                    ProductId = request.ProductId,
                    Qty = request.Qty,
                    InvoiceId = request.InvoiceId,
                };

                inventory.Qty -= invoiceDetail.Qty;

                invoice.SubTotal += _util.GetSimplePrice(invoiceDetail.Qty, product.Price);

                invoice.Total += _util.GeneratePriceFinal(invoiceDetail.Qty, product.Price, invoice.Discount,
                    invoice.Isv);

                _context.InvoicesDetail.Add(invoiceDetail);

                var value = await _context.SaveChangesAsync(cancellationToken);

                if (value > 0)
                    return Unit.Value;

                throw new Exception("The requested operation could not be performed.");
            }
        }
    }
}