using FelipEcommerce.Application.ErrorHandler;
using FelipEcommerce.Persistence;
using MediatR;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace FelipEcommerce.Application.Inventory
{
    public class EditInventory
    {
        public class CommandEditInventory : IRequest
        {
            public int Id { get; set; }
            public int? ProductId { get; set; }
            public int? Qty { get; set; }
            public DateTime? InventoryDate { get; set; }
        }

        public class Handler : IRequestHandler<CommandEditInventory>
        {
            private readonly FelipEcommerceContext _context;

            public Handler(FelipEcommerceContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CommandEditInventory request, CancellationToken cancellationToken)
            {
                var inventory = await _context.Inventory.FindAsync(request.Id);
                if (inventory == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new
                        {
                            message = $"The inventory record with the id {request.Id} does not exist. Please try again."
                        });

                var product = await _context.Products.FindAsync(request.ProductId);
                if (product == null)
                    throw new RestException(HttpStatusCode.NotFound, new
                        { message = $"There is no product associated with the id {request.ProductId}" });

                inventory.ProductId = (int)request.ProductId;
                inventory.Qty = request.Qty ?? inventory.Qty;
                inventory.InventoryDate = request.InventoryDate ?? inventory.InventoryDate;

                var value = await _context.SaveChangesAsync(cancellationToken);
                if (value > 0)
                    return Unit.Value;
                throw new Exception("");
            }
        }
    }
}