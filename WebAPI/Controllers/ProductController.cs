using Business.Abstract;
using Business.Requests.Product;
using Business.Responses.Product;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public GetProductListResponse GetList([FromQuery] GetProductListRequest request) { 
            
            GetProductListResponse response = _productService.GetList(request);
            return response;
        
        }

        [HttpPost]
        public ActionResult<AddProductResponse> AddProduct(AddProductRequest request)
        {
            AddProductResponse response = _productService.Add(request);
            return CreatedAtAction(nameof(GetList), response);
        }

        [HttpGet("elastic")]
        public ActionResult<GetProductListResponse> GetListFromElastic([FromQuery] GetProductListRequest request)
        {
        
            GetProductListResponse response = _productService.GetListFromElastic(request);
            
            return Ok(response);
        }
    }
}
