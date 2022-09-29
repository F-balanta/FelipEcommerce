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

        [HttpGet("client")]
        public async Task<ActionResult<List<ClientDto>>> List()
        {
            return await _mediator.Send(new GetAll.Query());
        }
    }
}
