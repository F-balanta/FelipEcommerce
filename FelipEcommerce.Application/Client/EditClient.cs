﻿using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FelipEcommerce.Persistence;
using MediatR;

namespace FelipEcommerce.Application.Client
{
    public class EditClient
    {
        public class CommandEditClient : IRequest
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Phone { get; set; }
            public string Dni { get; set; }
            public string Address { get; set; }
            public int? Age { get; set; }
        }

        public class Handler : IRequestHandler<CommandEditClient>
        {
            private readonly FelipEcommerceContext _context;

            public Handler(FelipEcommerceContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CommandEditClient request, CancellationToken cancellationToken)
            {
                var client = await _context.Clients.FindAsync(request.Id);
                if (client == null)
                    throw new System.NotImplementedException();

                client.FirstName = request.FirstName ?? client.FirstName;
                client.LastName = request.LastName ?? client.LastName;
                client.Phone = request.Phone ?? client.Phone;
                client.Dni = request.Dni ?? client.Dni;
                client.Address = request.Address ?? client.Address;
                client.Age = request.Age ?? client.Age;

                var value = await _context.SaveChangesAsync(cancellationToken);

                if (value > 0)
                    return Unit.Value;

                throw new Exception("");
            }
        }
    }
}