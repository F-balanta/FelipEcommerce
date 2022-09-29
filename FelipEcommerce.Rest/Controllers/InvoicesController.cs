using FelipEcommerce.Application.DAO;
using FelipEcommerce.Application.Invoice;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FelipEcommerce.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InvoicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<InvoiceDto>>> List()
        {
            return await _mediator.Send(new GetAllInvoices.Query());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<InvoiceDto>> GetInvoice(int id)
        {
            return await _mediator.Send(new GetInvoiceById.Query { Id = id });
        }
    }
}