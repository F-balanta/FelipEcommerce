﻿using AutoMapper;
using FelipEcommerce.Application.DAO;
using FelipEcommerce.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FelipEcommerce.Application.Inventory
{
    public class GetInventoryById
    {
        public class Query : IRequest<InventoryDto>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, InventoryDto>
        {
            private readonly FelipEcommerceContext _context;
            private readonly IMapper _mapper;

            public Handler(FelipEcommerceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<InventoryDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var inventory = await _context.Inventory
                    .Include(x => x.Product)
                    .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

                if (inventory == null)
                    throw new Exception("Inventory incorrect");

                var inventoryDto = _mapper.Map<InventoryDto>(inventory);
                return inventoryDto;
            }
        }
    }
}