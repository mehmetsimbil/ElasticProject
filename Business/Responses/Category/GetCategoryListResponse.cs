using Business.Dtos.Brand;
using Business.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Category
{
    public class GetCategoryListResponse
    {
        public GetCategoryListResponse()
        {
            Items = Array.Empty<CategoryListItemDto>();
        }

        public GetCategoryListResponse(ICollection<CategoryListItemDto> items)
        {
            Items = items;
        }

        public ICollection<CategoryListItemDto> Items { get; set; }

    }
}
