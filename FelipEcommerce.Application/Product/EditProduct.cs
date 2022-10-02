using AutoMapper;
using FelipEcommerce.Application.ErrorHandler;
using FelipEcommerce.Helpers.Interfaces;
using FelipEcommerce.Persistence;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace FelipEcommerce.Application.Product
{
    public class EditProduct
    {
        public class CommandEditProduct : IRequest
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string UrlImage { get; set; }
            public string Description { get; set; }
            [Column(TypeName = "decimal(18,2)")] public decimal? Price { get; set; }
        }

        public class Handler : IRequestHandler<CommandEditProduct>
        {
            private readonly FelipEcommerceContext _context;
            private readonly IMapper _mapper;
            private readonly IUtil _util;

            public Handler(FelipEcommerceContext context, IMapper mapper, IUtil util)
            {
                _context = context;
                _mapper = mapper;
                _util = util;
            }

            public async Task<Unit> Handle(CommandEditProduct request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.FindAsync(request.Id);
                if (product == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        $"There is no product associated with the id {request.Id}. Please try again");

                product.Name = request.Name ?? product.Name;
                product.Description = request.Description ?? product.Description;
                product.Price = request.Price ?? product.Price;

                if (request.UrlImage != null)
                {
                    if (_util.ImgUrlIsValid(request.UrlImage))
                        product.UrlImage = request.UrlImage;
                    else
                        throw new RestException(HttpStatusCode.BadRequest,
                            "The image url is invalid. Please try again.");
                }

                var value = await _context.SaveChangesAsync(cancellationToken);
                if (value > 0)
                    return Unit.Value;

                throw new Exception("The requested operation could not be performed.");
            }
        }
    }
}