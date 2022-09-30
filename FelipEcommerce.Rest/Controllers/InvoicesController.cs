using System;
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
            return await _mediator.Send(new GetInvoiceById.Query {Id = id});
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> CreateInvoice(CreateInvoice.CommandCreateInvoice data)
        {
            return await _mediator.Send(data);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Unit>> EditInvoice(int id, EditInvoice.CommandEditInvoice data)
        {
            data.Id = id;
            return await _mediator.Send(data);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Unit>> DropInvoice(int id)
        {
            return await _mediator.Send(new DeleteInvoice.CommandDeleteInvoice {Id = id});
        }
    }
}