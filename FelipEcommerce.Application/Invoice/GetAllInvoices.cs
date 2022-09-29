using AutoMapper;
using FelipEcommerce.Application.DAO;
using FelipEcommerce.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace FelipEcommerce.Application.Invoice
{
    public class GetAllInvoices
    {
        public class Query : IRequest<List<InvoiceDto>>
        {
        }

        public class Handler : IRequestHandler<Query, List<InvoiceDto>>
        {
            private readonly FelipEcommerceContext _context;
            private readonly IMapper _mapper;

            public Handler(FelipEcommerceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<InvoiceDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var invoices = await _context.Invoices
                    .Include(x => x.User)
                    .Include(x => x.Client)
                    .ToListAsync(cancellationToken: cancellationToken);

                var invoicesDto =
                    _mapper.Map<List<Domain.Models.Invoice>, List<InvoiceDto>>(invoices);

                return invoicesDto;
            }
        }
    }
}