using AutoMapper;
using Business.Dtos.Category;
using Business.Requests.Category;
using Business.Responses.Category;
using Entities.Concrete;


namespace Business.Profiles.AutoMapper
{
    public class CategoryMapperProfile : Profile
    {
        public CategoryMapperProfile()
        {
            CreateMap<AddCategoryRequest, Category>();
            CreateMap<Category, AddCategoryResponse>();

            CreateMap<Category, CategoryListItemDto>();
            CreateMap<IList<Category>, GetCategoryListResponse>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));
        }
    }
}
