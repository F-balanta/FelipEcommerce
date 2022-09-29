using AutoMapper;
using FelipEcommerce.Application.DAO;
using FelipEcommerce.Domain.Models;

namespace FelipEcommerce.Application.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Domain.Models.Client, ClientDto>()
                .ForMember(x => x.Invoices, y => y.MapFrom(z => z.Invoices))
                .ReverseMap();

            CreateMap<Inventory, InventoryDto>()
                .ForMember(x => x.Product, y => y.MapFrom(z => z.Product)).ReverseMap();

            CreateMap<Invoice, InvoiceDto>()
                .ForMember(x => x.User, y => y.MapFrom(z => z.User))
                .ForMember(x => x.InvoiceDetail, y => y.MapFrom(z => z.InvoiceDetail))
                .ForMember(x => x.Client, y => y.MapFrom(z => z.Client))
                .ReverseMap();

            CreateMap<InvoiceDetail, InvoiceDetailDto>()
                .ForMember(x => x.Invoice, y => y.MapFrom(z => z.Invoice))
                .ForMember(x => x.Product, y => y.MapFrom(z => z.Product))
                .ReverseMap();

            CreateMap<Product, ProductDto>()
                .ForMember(x => x.Inventory, y => y.MapFrom(z => z.Inventory))
                .ForMember(x => x.InvoiceDetails, y => y.MapFrom(z => z.InvoiceDetails))
                .ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();

            
        }
    }
}