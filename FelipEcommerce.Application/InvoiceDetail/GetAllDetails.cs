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
        public class Query : IRequest<List<InvoiceDetailDto>>
        {
        }

        public class Handler : IRequestHandler<Query, List<InvoiceDetailDto>>
        {
            private readonly FelipEcommerceContext _context;
            private readonly IMapper _mapper;

            public Handler(FelipEcommerceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<InvoiceDetailDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var invoiceDetail = await _context.InvoicesDetail
                    .ToListAsync(cancellationToken: cancellationToken);

                var invoiceDetailDto =
                    _mapper.Map<List<Domain.Models.InvoiceDetail>, List<InvoiceDetailDto>>(invoiceDetail);
                return invoiceDetailDto;
            }
        }
    }
}