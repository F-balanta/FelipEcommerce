using System;
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

        [HttpPost]
        public async Task<ActionResult<Unit>> CreateInventory(NewInventory.CommandInventory data)
        {
            return await _mediator.Send(data);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Unit>> UpdateInventory(int id, EditInventory.CommandEditInventory data)
        {
            data.Id = id;
            return await _mediator.Send(data);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Unit>> DeleteInventory(int id)
        {
            return await _mediator.Send(new DeleteInventory.CommandDelteInventory { Id = id });
        }
    }
}