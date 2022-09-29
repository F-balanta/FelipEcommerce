using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using FelipEcommerce.Persistence;

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
            public string Type { get; set; }
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
                    throw new NotImplementedException();

                inventory.ProductId = request.ProductId ?? inventory.ProductId;
                inventory.Qty = request.Qty ?? inventory.Qty;
                inventory.InventoryDate = request.InventoryDate ?? inventory.InventoryDate;
                inventory.Type = request.Type ?? inventory.Type;

                var value = await _context.SaveChangesAsync(cancellationToken);
                if (value > 0)
                    return Unit.Value;
                throw new Exception("");
            }
        }
    }
}