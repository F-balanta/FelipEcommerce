using System;
using FelipEcommerce.Application.DAO;
using FelipEcommerce.Application.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using FelipEcommerce.Application.Invoice;

namespace FelipEcommerce.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> ListUsers()
        {
            return await _mediator.Send(new GetUsers.Query());
        }

        [HttpGet("{userId:int}/Invoices")]
        public async Task<ActionResult<List<InvoiceWhitDetailsWithoutUserDto>>> GetInvoicesByUser(int userId)
        {
            return await _mediator.Send(new GetInvoicesByUser.Query { UserId = userId });
        }

        [HttpGet("{userId:int}/Invoices/{invoiceNumber}")]
        public async Task<ActionResult<InvoiceWhitDetailsWithoutUserDto>> GetInvoiceByUserByInvoiceId(int userId,
            string invoiceNumber)
        {
            return await _mediator.Send(new GetInvoiceByUser.Query { UserId = userId, InvoiceNumber = invoiceNumber });
        }
    }
}