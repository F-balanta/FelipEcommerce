using AutoMapper;
using FelipEcommerce.Application.DAO;
using FelipEcommerce.Application.ErrorHandler;
using FelipEcommerce.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace FelipEcommerce.Application.Invoice
{
    public class GetInvoiceWithDetailByInvoiceNumber
    {
        public class Query : IRequest<InvoiceWithInvoiceDetailsDto>
        {
            public string InvoiceNumber { get; set; }
        }

        public class Handler : IRequestHandler<Query, InvoiceWithInvoiceDetailsDto>
        {
            private readonly FelipEcommerceContext _context;
            private readonly IMapper _mapper;

            public Handler(FelipEcommerceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<InvoiceWithInvoiceDetailsDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var invoice = await _context.Invoices
                    .Include(x => x.User)
                    .Include(x => x.Client)
                    .Include(x => x.InvoiceDetail)
                    .ThenInclude(x => x.Product)
                    .FirstOrDefaultAsync(x => x.InvoiceNumber.Equals(request.InvoiceNumber),
                        cancellationToken: cancellationToken);

                if (invoice == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new
                        {
                            message = $"There is no invoice associated with the invoice number {request.InvoiceNumber}"
                        });

                var invoiceDto = _mapper.Map<InvoiceWithInvoiceDetailsDto>(invoice);
                return invoiceDto;
            }
        }
    }
}