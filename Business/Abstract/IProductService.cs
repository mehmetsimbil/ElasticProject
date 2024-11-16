using Business.Requests.Product;
using Business.Responses.Product;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IProductService
    {
        public AddProductResponse Add(AddProductRequest request);
        public GetProductListResponse GetList(GetProductListRequest request);
        void IndexProduct(Product product);
        public GetProductListResponse GetListFromElastic(GetProductListRequest request);
    }
}
