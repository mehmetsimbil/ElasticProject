using Business.Abstract;
using Business.Requests.Product;
using Business.Responses.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        public AddProductResponse Add(AddProductRequest request)
        {
            throw new NotImplementedException();
        }

        public GetProductListResponse GetList(GetProductListRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
