using Business.Abstract;
using Business.Requests.Category;
using Business.Responses.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        public AddCategoryResponse Add(AddCategoryRequest request)
        {
            throw new NotImplementedException();
        }

        public GetCategoryListResponse GetList(GetCategoryListRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
