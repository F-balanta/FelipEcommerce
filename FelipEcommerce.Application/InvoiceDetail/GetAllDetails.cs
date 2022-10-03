using AutoMapper;
using FelipEcommerce.Application.DAO;
using FelipEcommerce.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace FelipEcommerce.Application.InvoiceDetail
{
    public class GetAllDetails
    {
        public class Query : IRequest<List<InvoiceDetailWithProductDto>>
        {
        }

        public class Handler : IRequestHandler<Query, List<InvoiceDetailWithProductDto>>
        {
            private readonly FelipEcommerceContext _context;
            private readonly IMapper _mapper;

            public Handler(FelipEcommerceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<InvoiceDetailWithProductDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var invoiceDetail = await _context.InvoicesDetail
                    .Include(x => x.Product)
                    .ToListAsync(cancellationToken: cancellationToken);

                var invoiceDetailDto =
                    _mapper.Map<List<Domain.Models.InvoiceDetail>, List<InvoiceDetailWithProductDto>>(invoiceDetail);
                return invoiceDetailDto;
            }
        }
    }
}