using FelipEcommerce.Application.DAO;
using FelipEcommerce.Application.InvoiceDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FelipEcommerce.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceDetailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InvoiceDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<InvoiceDetailDto>> List()
        {
            return await _mediator.Send(new GetAllDetails.Query());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<InvoiceDetailDto>> GetInvoiceDetail(int id)
        {
            return await _mediator.Send(new GetInvoiceDetailById.Query { Id = id });
        }
    }
}