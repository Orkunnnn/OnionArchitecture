using AutoMapper;
using OnionArchitecture.Application.ViewModels.Products;
using OnionArchitecture.Domain.Entities;

namespace OnionArchitecture.Application.Mappings.AutoMapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, GetProductViewModel>().ForMember(p => p.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<Product, UpdateProductViewModel>().ReverseMap();
        }
    }
}
