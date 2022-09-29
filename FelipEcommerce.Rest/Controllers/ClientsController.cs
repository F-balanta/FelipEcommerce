using FelipEcommerce.Application.Client;
using FelipEcommerce.Application.DAO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FelipEcommerce.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClientDto>>> GetClients()
        {
            return await _mediator.Send(new GetAll.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDto>> GetClient(int id)
        {
            return await _mediator.Send(new GetClientById.Query { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> CreateClient(CreateClient.CommandCreateClient data)
        {
            return await _mediator.Send(data);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Unit>> EditClient(int id, EditClient.CommandEditClient data)
        {
            data.Id = id;
            return await _mediator.Send(data);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Unit>> DeleteClient(int id)
        {
            return await _mediator.Send(new DeleteClient.CommandDeleteClient { Id = id });
        }
    }
}