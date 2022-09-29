using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FelipEcommerce.Application.DAO;
using FelipEcommerce.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FelipEcommerce.Application.Inventory
{
    public class GetAllInventory
    {
        public class Query : IRequest<List<InventoryDto>>
        {
        }

        public class Handler : IRequestHandler<Query, List<InventoryDto>>
        {
            private readonly IMapper _mapper;
            private readonly FelipEcommerceContext _context;

            public Handler(IMapper mapper, FelipEcommerceContext context)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<List<InventoryDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var inventory = await _context.Inventory
                    .Include(x => x.Product)
                    .ToListAsync(cancellationToken: cancellationToken);

                var inventoryDto = _mapper.Map<List<InventoryDto>>(inventory);
                return inventoryDto;
            }
        }
    }
}