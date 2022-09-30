using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FelipEcommerce.Application.ErrorHandler;
using FelipEcommerce.Persistence;
using MediatR;

namespace FelipEcommerce.Application.Product
{
    public class DeleteProduct
    {
        public class CommandDeleteProduct : IRequest
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<CommandDeleteProduct>
        {
            private readonly FelipEcommerceContext _context;

            public Handler(FelipEcommerceContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CommandDeleteProduct request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.FindAsync(request.Id);
                if (product == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        $"There is no product associated with the id {request.Id}. Please try again");

                _context.Products.Remove(product);

                var value = await _context.SaveChangesAsync(cancellationToken);

                if (value > 0)
                    return Unit.Value;

                throw new Exception("The requested operation could not be performed.");
            }
        }
    }
}