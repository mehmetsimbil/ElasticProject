using Business.Dtos.Brand;
using Business.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Product
{
    public class GetProductListResponse
    {
        public GetProductListResponse()
        {
            Items = Array.Empty<ProductListItemDto>();
        }

        public GetProductListResponse(ICollection<ProductListItemDto> ıtems)
        {
            Items = ıtems;
        }

        public ICollection<ProductListItemDto> Items { get; set; }

    }
}
