using AutoMapper;
using FelipEcommerce.Application.DAO;

namespace FelipEcommerce.Application.Profiles
{
    public class InvoicesProfile : Profile
    {
        public InvoicesProfile()
        {
            CreateMap<Domain.Models.Client, ClientDtoWithoutInvoices>();

            CreateMap<Domain.Models.Client, ClientDto>();

            CreateMap<Domain.Models.Client, ClientDto>()
                .ForMember(x => x.Invoices, y => y.MapFrom(z => z.Invoices)).ReverseMap();


            CreateMap<Domain.Models.User, UserWithoutInvoicesDto>().ReverseMap();

            CreateMap<Domain.Models.User, UserDto>().ReverseMap()
                .ForMember(x => x.Invoices, y => y.MapFrom(z => z.Invoices)).ReverseMap();


            CreateMap<Domain.Models.Invoice, InvoiceDto>()
                .ForMember(x => x.User, y => y.MapFrom(z => z.User))
                .ReverseMap();

            CreateMap<Domain.Models.Invoice, InvoiceWithInvoiceDetailsDto>()
                .ForMember(x => x.User, y => y.MapFrom(z => z.User))
                .ForMember(x => x.InvoiceDetails, y => y.MapFrom(z => z.InvoiceDetail))
                .ReverseMap();

            CreateMap<Domain.Models.Invoice, InvoiceWithDetailsWithoutClientDto>()
                .ForMember(x => x.User, y => y.MapFrom(z => z.User))
                .ForMember(x => x.InvoiceDetails, y => y.MapFrom(z => z.InvoiceDetail))
                .ReverseMap();

            CreateMap<Domain.Models.Invoice, InvoiceWhitDetailsWithoutUserDto>()
                .ForMember(x => x.Client, y => y.MapFrom(z => z.Client))
                .ForMember(x => x.InvoiceDetails, y => y.MapFrom(z => z.InvoiceDetail))
                .ReverseMap();

            CreateMap<Domain.Models.Invoice, InvoiceWithoutClientDto>()
                .ForMember(x => x.User, y => y.MapFrom(z => z.User))
                .ReverseMap();

            CreateMap<Domain.Models.Invoice, InvoiceWithoutUserDto>()
                .ForMember(x => x.Client, y => y.MapFrom(z => z.Client))
                .ReverseMap();


            CreateMap<Domain.Models.InvoiceDetail, InvoiceDetailDto>();

            CreateMap<Domain.Models.InvoiceDetail, InvoiceDetailWithProductDto>()
                .ForMember(x => x.Product, y => y.MapFrom(z => z.Product))
                .ReverseMap();

            CreateMap<Domain.Models.Product, ProductDto>().ReverseMap();

            CreateMap<Domain.Models.Inventory, InventoryDto>().ReverseMap();
        }
    }
}