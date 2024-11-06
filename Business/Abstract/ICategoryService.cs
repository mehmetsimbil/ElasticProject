using Business.Requests.Category;
using Business.Responses.Category;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        public AddCategoryResponse Add(AddCategoryRequest request);
        public GetCategoryListResponse GetList(GetCategoryListRequest request);
    }
}
