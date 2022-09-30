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

namespace FelipEcommerce.Application.Client
{
    public class GetClientById
    {
        public class Query : IRequest<ClientDto>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ClientDto>
        {
            private readonly FelipEcommerceContext _context;
            private readonly IMapper _mapper;

            public Handler(FelipEcommerceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ClientDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var client = await _context.Clients
                    .Include(x => x.Invoices)
                    .ThenInclude(x => x.User)
                    .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

                if (client == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new {message = $"There is no customer associated with the id {request.Id}. Please try again."});

                var clientDto = _mapper.Map<ClientDto>(client);
                return clientDto;
            }
        }
    }
}