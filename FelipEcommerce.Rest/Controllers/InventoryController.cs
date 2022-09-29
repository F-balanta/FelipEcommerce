using System.Collections.Generic;
using System.Threading.Tasks;
using FelipEcommerce.Application.DAO;
using FelipEcommerce.Application.Inventory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FelipEcommerce.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InventoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<InventoryDto>>> List()
        {
            return await _mediator.Send(new GetAllInventory.Query());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<InventoryDto>> GetInventory(int id)
        {
            return await _mediator.Send(new GetInventoryById.Query { Id = id });
        }
    }
}