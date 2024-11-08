using AutoMapper;
using Business.Dtos.Product;
using Business.Requests.Product;
using Business.Responses.Product;
using Entities.Concrete;

namespace Business.Profiles.AutoMapper
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<AddProductRequest, Product>();
            CreateMap<Product, AddProductResponse>();
            CreateMap<Product, ProductListItemDto>();
            CreateMap<IList<Product>, GetProductListResponse>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));
        }
    }
}
