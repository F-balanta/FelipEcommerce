using AutoMapper;
using FelipEcommerce.Application.DAO;
using FelipEcommerce.Application.ErrorHandler;
using FelipEcommerce.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace FelipEcommerce.Application.Invoice
{
    public class GetInvoiceByClient
    {
        public class Query : IRequest<InvoiceWithDetailsWithoutClientDto>
        {
            public int ClientId { get; set; }
            public string InvoiceNumber { get; set; }
        }

        public class Handler : IRequestHandler<Query, InvoiceWithDetailsWithoutClientDto>
        {
            private readonly IMapper _mapper;
            private readonly FelipEcommerceContext _context;

            public Handler(IMapper mapper, FelipEcommerceContext context)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<InvoiceWithDetailsWithoutClientDto> Handle(Query request,
                CancellationToken cancellationToken)
            {
                var invoices = await _context.Invoices.Where(x => x.ClientId == request.ClientId)
                    .Include(x => x.User)
                    .Include(x => x.InvoiceDetail)
                    .ThenInclude(x => x.Product)
                    .ToListAsync(cancellationToken: cancellationToken);

                if (invoices == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new { message = "There are no invoices associated with this customer" });

                var invoice = invoices.FirstOrDefault(x => x.InvoiceNumber.Equals(request.InvoiceNumber));
                if (invoice == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new { message = $"The invoice {request.InvoiceNumber} is not associated with this customer" });

                var invoiceDto = _mapper.Map<Domain.Models.Invoice, InvoiceWithDetailsWithoutClientDto>(invoice);

                return invoiceDto;
            }
        }
    }
}