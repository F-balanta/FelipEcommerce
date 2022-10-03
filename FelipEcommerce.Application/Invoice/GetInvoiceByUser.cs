using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
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
    public class GetInvoiceByUser
    {
        public class Query : IRequest<InvoiceWhitDetailsWithoutUserDto>
        {
            public int UserId { get; set; }
            public string InvoiceNumber { get; set; }
        }

        public class Handler : IRequestHandler<Query, InvoiceWhitDetailsWithoutUserDto>
        {
            private readonly IMapper _mapper;
            private readonly FelipEcommerceContext _context;

            public Handler(IMapper mapper, FelipEcommerceContext context)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<InvoiceWhitDetailsWithoutUserDto> Handle(Query request,
                CancellationToken cancellationToken)
            {
                var invoices = await _context.Invoices.Where(x => x.ClientId == request.UserId)
                    .Include(x => x.Client)
                    .Include(x => x.InvoiceDetail)
                    .ThenInclude(x => x.Product)
                    .ToListAsync(cancellationToken: cancellationToken);

                if (invoices == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new { message = "There are no invoices associated with this user" });

                var invoice = invoices.FirstOrDefault(x => x.InvoiceNumber.Equals(request.InvoiceNumber));
                if (invoice == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new { message = $"The invoice {request.InvoiceNumber} is not associated with this user" });

                var invoiceDto = _mapper.Map<Domain.Models.Invoice, InvoiceWhitDetailsWithoutUserDto>(invoice);

                return invoiceDto;
            }
        }
    }
}