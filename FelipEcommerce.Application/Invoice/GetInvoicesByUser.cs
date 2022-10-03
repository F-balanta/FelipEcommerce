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
    public class GetInvoicesByUser
    {
        public class Query : IRequest<List<InvoiceWhitDetailsWithoutUserDto>>
        {
            public int UserId { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<InvoiceWhitDetailsWithoutUserDto>>
        {
            private readonly FelipEcommerceContext _context;
            private readonly IMapper _mapper;

            public Handler(FelipEcommerceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<InvoiceWhitDetailsWithoutUserDto>> Handle(Query request,
                CancellationToken cancellationToken)
            {
                var invoices = await _context.Invoices.Where(x => x.ClientId == request.UserId)
                    .Include(x => x.Client)
                    .Include(x => x.InvoiceDetail)
                    .ThenInclude(x => x.Product)
                    .ToListAsync(cancellationToken: cancellationToken);

                if (invoices == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new { message = "No invoices were found associated with this user" });

                var invoicesDto =
                    _mapper.Map<List<Domain.Models.Invoice>, List<InvoiceWhitDetailsWithoutUserDto>>(invoices);

                return invoicesDto;
            }
        }
    }
}