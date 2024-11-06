using AutoMapper;
using Business.Dtos.Brand;
using Business.Requests.Brand;
using Business.Responses.Brand;
using Entities.Concrete;

namespace Business.Profiles.AutoMapper
{
    public class BrandMapperProfile : Profile
    {
        public BrandMapperProfile()
        {
            CreateMap<AddBrandRequest, Brand>();
            CreateMap<Brand, AddBrandResponse>();

            CreateMap<Brand, BrandListItemDto>();
            CreateMap<IList<Brand>, GetBrandListResponse>()
                .ForMember(dest=>dest.Items,opt=>opt.MapFrom(src=>src));
        }
    }
}
