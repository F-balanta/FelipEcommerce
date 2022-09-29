using AutoMapper;
using FelipEcommerce.Persistence;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

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

            public Handler(FelipEcommerceContext contex, IMapper mapper)
            {
                _contex = contex;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(CommandCreateProduct request, CancellationToken cancellationToken)
            {
                var product = new Domain.Models.Product
                {
                    Name = request.Name,
                    UrlImage = request.UrlImage,
                    Description = request.Description,
                    Price = request.Price,
                };

                _contex.Products.Add(product);

                var value = await _contex.SaveChangesAsync(cancellationToken);

                if (value > 0)
                    return Unit.Value;

                throw new NotImplementedException();
            }
        }
    }
}