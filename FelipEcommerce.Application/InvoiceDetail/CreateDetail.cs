using MediatR;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FelipEcommerce.Persistence;

namespace FelipEcommerce.Application.InvoiceDetail
{
    public class CreateDetail
    {
        public class CommandCreateInvoiceDetail : IRequest
        {
            public int ProductId { get; set; }
            public int Qty { get; set; }
            public int InvoiceId { get; set; }
            [Column(TypeName = "decimal(18,2)")] public decimal Price { get; set; }
        }

        public class Handler : IRequestHandler<CommandCreateInvoiceDetail>
        {
            private readonly FelipEcommerceContext _context;
            private readonly IMapper _mapper;

            public Handler(FelipEcommerceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(CommandCreateInvoiceDetail request, CancellationToken cancellationToken)
            {
                var invoiceDetail = new Domain.Models.InvoiceDetail
                {
                    ProductId = request.ProductId,
                    Qty = request.Qty,
                    Price = request.Price,
                    InvoiceId = request.InvoiceId,
                };

                _context.InvoicesDetail.Add(invoiceDetail);

                var value = await _context.SaveChangesAsync(cancellationToken);

                if (value > 0)
                    return Unit.Value;

                throw new System.NotImplementedException();
            }
        }
    }
}