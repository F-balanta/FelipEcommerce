using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FelipEcommerce.Application.DAO;
using FelipEcommerce.Application.ErrorHandler;
using FelipEcommerce.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FelipEcommerce.Application.InvoiceDetail
{
    public class GetInvoiceDetailById
    {
        public class Query : IRequest<InvoiceDetailDto>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, InvoiceDetailDto>
        {
            private readonly FelipEcommerceContext _context;
            private readonly IMapper _mapper;

            public Handler(FelipEcommerceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<InvoiceDetailDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var invoiceDetail = await _context.InvoicesDetail
                    .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

                if (invoiceDetail == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new
                        {
                            message =
                                $"There is no detailed invoice record associated with the id {request.Id}. Please try again."
                        });

                var invoiceDetailDto = _mapper.Map<InvoiceDetailDto>(invoiceDetail);
                return invoiceDetailDto;
            }
        }
    }
}