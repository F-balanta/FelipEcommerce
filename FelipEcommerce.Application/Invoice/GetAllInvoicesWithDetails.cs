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
    public class GetAllInvoicesWithDetails
    {
        public class Query : IRequest<List<InvoiceWithInvoiceDetailsDto>>
        {
        }

        public class Handler : IRequestHandler<Query, List<InvoiceWithInvoiceDetailsDto>>
        {
            private readonly IMapper _mapper;
            private readonly FelipEcommerceContext _context;

            public Handler(IMapper mapper, FelipEcommerceContext context)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<List<InvoiceWithInvoiceDetailsDto>> Handle(Query request,
                CancellationToken cancellationToken)
            {
                var invoices = await _context.Invoices
                    .Include(x => x.Client)
                    .Include(x => x.User)
                    .Include(x => x.InvoiceDetail)
                    .ThenInclude(x => x.Product)
                    .ToListAsync(cancellationToken: cancellationToken);

                var invoicesDto =
                    _mapper.Map<List<Domain.Models.Invoice>, List<InvoiceWithInvoiceDetailsDto>>(invoices);

                return invoicesDto;
            }
        }
    }
}