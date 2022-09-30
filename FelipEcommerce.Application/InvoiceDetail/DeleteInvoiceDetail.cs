﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FelipEcommerce.Persistence;
using MediatR;

namespace FelipEcommerce.Application.InvoiceDetail
{
    public class DeleteInvoiceDetail
    {
        public class CommandDeleteEnvoiceDetail : IRequest
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<CommandDeleteEnvoiceDetail>
        {
            private readonly FelipEcommerceContext _context;

            public Handler(FelipEcommerceContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CommandDeleteEnvoiceDetail request, CancellationToken cancellationToken)
            {
                var envoideDetail = await _context.InvoicesDetail.FindAsync(request.Id);
                if (envoideDetail == null)
                    throw new NotImplementedException();

                _context.InvoicesDetail.Remove(envoideDetail);

                var value = await _context.SaveChangesAsync(cancellationToken);

                if (value > 0)
                    return Unit.Value;
                throw new Exception("");
            }
        }
    }
}