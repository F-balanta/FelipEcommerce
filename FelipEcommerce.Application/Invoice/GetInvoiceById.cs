using AutoMapper;
using FelipEcommerce.Application.DAO;
using FelipEcommerce.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FelipEcommerce.Application.ErrorHandler;

namespace FelipEcommerce.Application.Invoice
{
    public class GetInvoiceById
    {
        public class Query : IRequest<InvoiceDto>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, InvoiceDto>
        {
            private readonly FelipEcommerceContext _context;
            private readonly IMapper _mapper;

            public Handler(FelipEcommerceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<InvoiceDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var invoice = await _context.Invoices
                    .Include(x => x.User)
                    .Include(x => x.Client)
                    .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

                if (invoice == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new { message = $"There is no invoice associated with the id {request.Id}" });

                var invoiceDto = _mapper.Map<InvoiceDto>(invoice);
                return invoiceDto;
            }
        }
    }
}