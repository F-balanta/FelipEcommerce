using AutoMapper;
using FelipEcommerce.Application.ErrorHandler;
using FelipEcommerce.Persistence;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace FelipEcommerce.Application.Inventory
{
    public class NewInventory
    {
        public class CommandInventory : IRequest
        {
            public int ProductId { get; set; }
            public int Qty { get; set; }
            [Column(TypeName = "Date")] public DateTime InventoryDate { get; set; }
        }

        public class Handler : IRequestHandler<CommandInventory>
        {
            private readonly FelipEcommerceContext _context;
            private readonly IMapper _mapper;

            public Handler(FelipEcommerceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(CommandInventory request, CancellationToken cancellationToken)
            {
                var inventory = new Domain.Models.Inventory
                {
                    Qty = request.Qty,
                    InventoryDate = request.InventoryDate
                };

                var product = await _context.Products.FindAsync(request.ProductId);
                if (product == null)
                    throw new RestException(HttpStatusCode.NotFound, new
                        { message = $"There is no product associated with the id {request.ProductId}" });

                inventory.ProductId = request.ProductId;

                _context.Inventory.Add(inventory);

                var value = await _context.SaveChangesAsync(cancellationToken);

                if (value > 0)
                    return Unit.Value;
                throw new NotImplementedException();
            }
        }
    }
}