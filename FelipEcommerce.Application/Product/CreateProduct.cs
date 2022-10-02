using AutoMapper;
using FelipEcommerce.Application.ErrorHandler;
using FelipEcommerce.Persistence;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FelipEcommerce.Helpers.Interfaces;

namespace FelipEcommerce.Application.Product
{
    public class CreateProduct
    {
        public class CommandCreateProduct : IRequest
        {
            public string Name { get; set; }
            public string UrlImage { get; set; }
            public string Description { get; set; }
            [Column(TypeName = "decimal(18,2)")] public decimal Price { get; set; }
        }

        public class Handler : IRequestHandler<CommandCreateProduct>
        {
            private readonly FelipEcommerceContext _contex;
            private readonly IMapper _mapper;
            private readonly IUtil _util;

            public Handler(FelipEcommerceContext contex, IMapper mapper, IUtil util)
            {
                _contex = contex;
                _mapper = mapper;
                _util = util;
            }

            public async Task<Unit> Handle(CommandCreateProduct request, CancellationToken cancellationToken)
            {
                var product = new Domain.Models.Product
                {
                    Name = request.Name,
                    Description = request.Description,
                    Price = request.Price,
                };

                if (request.UrlImage != null)
                {
                    if (_util.ImgUrlIsValid(request.UrlImage))
                        product.UrlImage = request.UrlImage;
                    else
                        throw new RestException(HttpStatusCode.BadRequest, "The image url is invalid. Please try again.");
                }

                _contex.Products.Add(product);

                var value = await _contex.SaveChangesAsync(cancellationToken);

                if (value > 0)
                    return Unit.Value;

                throw new Exception("The requested operation could not be performed.");
            }
        }
    }
}