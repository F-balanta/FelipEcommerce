using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FelipEcommerce.Application.DAO;
using FelipEcommerce.Application.ErrorHandler;
using FelipEcommerce.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FelipEcommerce.Application.Invoice
{
    public class GetInvoicesByClient
    {
        public class Query : IRequest<List<InvoiceWithDetailsWithoutClientDto>>
        {
            public int ClientId { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<InvoiceWithDetailsWithoutClientDto>>
        {
            private readonly FelipEcommerceContext _context;
            private readonly IMapper _mapper;

            public Handler(FelipEcommerceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<InvoiceWithDetailsWithoutClientDto>> Handle(Query request,
                CancellationToken cancellationToken)
            {
                var invoices = await _context.Invoices.Where(x => x.ClientId == request.ClientId)
                    .Include(x => x.User)
                    .Include(x => x.InvoiceDetail)
                    .ThenInclude(x => x.Product)
                    .ToListAsync(cancellationToken: cancellationToken);

                if (invoices == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new { message = "No invoices were found associated with this customer" });

                var invoicesDto =
                    _mapper.Map<List<Domain.Models.Invoice>, List<InvoiceWithDetailsWithoutClientDto>>(invoices);

                return invoicesDto;
            }
        }
    }
}