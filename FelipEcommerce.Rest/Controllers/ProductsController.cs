using System.Collections.Generic;
using System.Threading.Tasks;
using FelipEcommerce.Application.DAO;
using FelipEcommerce.Application.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FelipEcommerce.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> List()
        {
            return await _mediator.Send(new GetAllProducts.Query());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)

        {
            return await _mediator.Send(new GetProductById.Query {Id = id});
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> CreateProduct(CreateProduct.CommandCreateProduct data)
        {
            return await _mediator.Send(data);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Unit>> UpdateProduct(int id, EditProduct.CommandEditProduct data)
        {
            data.Id = id;
            return await _mediator.Send(data);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Unit>> DeleteProduct(int id)
        {
            return await _mediator.Send(new DeleteProduct.CommandDeleteProduct {Id = id});
        }
    }
}