using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using FelipEcommerce.Persistence;

namespace FelipEcommerce.Application.Inventory
{
    public class DeleteInventory
    {
        public class CommandDelteInventory : IRequest
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<CommandDelteInventory>
        {
            private readonly FelipEcommerceContext _context;

            public Handler(FelipEcommerceContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CommandDelteInventory request, CancellationToken cancellationToken)
            {
                var inventory = await _context.Inventory.FindAsync(request.Id);
                if (inventory == null)
                    throw new NotImplementedException();
                _context.Inventory.Remove(inventory);
                var value = await _context.SaveChangesAsync(cancellationToken);
                if (value > 0)
                    return Unit.Value;
                throw new Exception("");
            }
        }
    }
}