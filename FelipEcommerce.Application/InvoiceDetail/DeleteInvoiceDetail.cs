using FelipEcommerce.Application.ErrorHandler;
using FelipEcommerce.Persistence;
using MediatR;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FelipEcommerce.Helpers.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FelipEcommerce.Application.InvoiceDetail
{
    public class DeleteInvoiceDetail
    {
        public class CommandDeleteEnvoiceDetail : IRequest
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<CommandDeleteEnvoiceDetail>
        {
            private readonly FelipEcommerceContext _context;
            private readonly IUtil _util;

            public Handler(FelipEcommerceContext context, IUtil util)
            {
                _context = context;
                _util = util;
            }

            public async Task<Unit> Handle(CommandDeleteEnvoiceDetail request, CancellationToken cancellationToken)
            {
                var invoiceDetail = await _context.InvoicesDetail.FindAsync(request.Id);
                if (invoiceDetail == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new
                        {
                            message =
                                $"There is no detailed invoice record associated with the id {request.Id}. Please try again."
                        });

                var product = await _context.Products.FindAsync(invoiceDetail.ProductId);
                if (product == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new { message = $"There is no product with the id {product.Id}. Please try again" });

                var invoice = await _context.Invoices.FindAsync(invoiceDetail.InvoiceId);
                if (invoice == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new { message = $"There is no invoice associated with the id {invoiceDetail.InvoiceId}" });

                invoice.SubTotal -= _util.GetSimplePrice(invoiceDetail.Qty, product.Price);

                invoice.Total -= _util.GeneratePriceFinal(invoiceDetail.Qty, product.Price, invoice.Discount,
                    invoice.Isv);

                var inventory = await _context.Inventory.FirstOrDefaultAsync(x => x.ProductId == product.Id,
                    cancellationToken: cancellationToken);

                if (inventory != null)
                    inventory.Qty += invoiceDetail.Qty;

                _context.InvoicesDetail.Remove(invoiceDetail);

                var value = await _context.SaveChangesAsync(cancellationToken);

                if (value > 0)
                    return Unit.Value;

                throw new Exception("The requested operation could not be performed.");
            }
        }
    }
}