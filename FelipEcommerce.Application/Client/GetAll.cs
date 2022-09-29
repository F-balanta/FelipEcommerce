using AutoMapper;
using FelipEcommerce.Application.DAO;
using FelipEcommerce.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FelipEcommerce.Application.Client
{
    public class GetAll
    {
        public class Query : IRequest<List<ClientDto>>
        {
        }

        public class Handler : IRequestHandler<Query, List<ClientDto>>
        {
            private readonly FelipEcommerceContext _context;
            private readonly IMapper _mapper;

            public Handler(FelipEcommerceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<ClientDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var clients = await _context.Clients
                    .Include(x => x.Invoices)
                    .ThenInclude(x => x.User)
                    .ToListAsync(cancellationToken: cancellationToken);

                var clientsDto = _mapper.Map<List<ClientDto>>(clients);
                return clientsDto;
            }
        }
    }
}