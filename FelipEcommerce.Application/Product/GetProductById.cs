using AutoMapper;
using FelipEcommerce.Application.DAO;
using FelipEcommerce.Application.ErrorHandler;
using FelipEcommerce.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace FelipEcommerce.Application.Product
{
    public class GetProductById
    {
        public class Query : IRequest<ProductDto>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ProductDto>
        {
            private readonly FelipEcommerceContext _context;
            private readonly IMapper _mapper;

            public Handler(FelipEcommerceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ProductDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var product = await _context.Products
                    .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

                if (product == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        $"There is no product associated with the id {request.Id}. Please try again");

                var productDto = _mapper.Map<ProductDto>(product);
                return productDto;
            }
        }
    }
}