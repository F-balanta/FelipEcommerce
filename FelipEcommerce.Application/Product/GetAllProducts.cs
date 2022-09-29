using AutoMapper;
using FelipEcommerce.Application.DAO;
using FelipEcommerce.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace FelipEcommerce.Application.Product
{
    public class GetAllProducts
    {
        public class Query : IRequest<List<ProductDto>>
        {
        }

        public class Handler : IRequestHandler<Query, List<ProductDto>>
        {
            private readonly FelipEcommerceContext _context;
            private readonly IMapper _mapper;

            public Handler(FelipEcommerceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<ProductDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var products = await _context.Products
                    .ToListAsync(cancellationToken: cancellationToken);

                var productDto =
                    _mapper.Map<List<Domain.Models.Product>, List<ProductDto>>(products);
                return productDto;
            }
        }
    }
}