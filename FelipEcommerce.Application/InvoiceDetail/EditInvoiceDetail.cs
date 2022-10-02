using AutoMapper;
using FelipEcommerce.Application.ErrorHandler;
using FelipEcommerce.Helpers.Interfaces;
using FelipEcommerce.Persistence;
using MediatR;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
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
        }

        public class Handler : IRequestHandler<CommandEditInvoiceDetail>
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

            public async Task<Unit> Handle(CommandEditInvoiceDetail request, CancellationToken cancellationToken)
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

                var newProduct = await _context.Products.FindAsync(request.ProductId);
                if (newProduct == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new { message = $"There is no product with the id {request.ProductId}. Please try again" });

                var invoice = await _context.Invoices.FindAsync(invoiceDetail.InvoiceId);
                if (invoice == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new { message = $"There is no invoice associated with the id {invoiceDetail.InvoiceId}" });

                var inventory = await _context.Inventory.FirstOrDefaultAsync(x => x.ProductId == product.Id,
                    cancellationToken: cancellationToken);

                var newInventory = await _context.Inventory.FirstOrDefaultAsync(x => x.ProductId == newProduct.Id,
                    cancellationToken: cancellationToken);

                if (newInventory == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new { message = "The desired product is not in stock" });

                if (inventory == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new { message = "The desired product is not in stock" });

                if (newInventory.Qty < request.Qty)
                    throw new RestException(HttpStatusCode.BadRequest,
                        new { message = "The quantity of products desired exceeds the quantity available in stock." });

                inventory.Qty += invoiceDetail.Qty;

                //TODO: Falta terminar la de implementar la lógica al momento de actualizar y eliminar, para que se afecte el inventario

                invoice.SubTotal -= _util.GetSimplePrice(invoiceDetail.Qty, product.Price);

                invoice.Total -= _util.GeneratePriceFinal(invoiceDetail.Qty, product.Price, invoice.Discount,
                    invoice.Isv);

                invoiceDetail.ProductId = request.ProductId ?? invoiceDetail.ProductId;
                invoiceDetail.Qty = request.Qty ?? invoiceDetail.Qty;

                invoice.SubTotal += _util.GetSimplePrice(invoiceDetail.Qty, product.Price);

                invoice.Total += _util.GeneratePriceFinal(invoiceDetail.Qty, product.Price, invoice.Discount,
                    invoice.Isv);

                newInventory.Qty -= invoiceDetail.Qty;

                var value = await _context.SaveChangesAsync(cancellationToken);
                if (value > 0)
                    return Unit.Value;

                throw new Exception("The requested operation could not be performed.");
            }
        }
    }
}