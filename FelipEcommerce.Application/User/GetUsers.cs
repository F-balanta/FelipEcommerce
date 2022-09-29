using AutoMapper;
using FelipEcommerce.Application.DAO;
using FelipEcommerce.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace FelipEcommerce.Application.User
{
    public class GetUsers
    {
        public class Query : IRequest<List<UserDto>>
        {
        }

        public class Handler : IRequestHandler<Query, List<UserDto>>
        {
            private readonly FelipEcommerceContext _context;
            private readonly IMapper _mapper;

            public Handler(FelipEcommerceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<UserDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var users = await _context.Users
                    .Include(x => x.Invoices)
                    .ThenInclude(x => x.Client)
                    .ToListAsync(cancellationToken: cancellationToken);

                var usersDto = _mapper.Map<List<Domain.Models.User>, List<UserDto>>(users);
                return usersDto;
            }
        }
    }
}