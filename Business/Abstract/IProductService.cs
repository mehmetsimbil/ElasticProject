using Business.Requests.Product;
using Business.Responses.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        public AddProductResponse Add(AddProductRequest request);
        public GetProductListResponse GetList(GetProductListRequest request);
    }
}
