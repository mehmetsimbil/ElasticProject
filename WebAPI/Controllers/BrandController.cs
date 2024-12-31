using Business.Abstract;
using Business.Requests.Brand;
using Business.Responses.Brand;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public GetBrandListResponse GetList([FromQuery] GetBrandListRequest request)
        {
            GetBrandListResponse response = _brandService.GetList(request);
            return response;
        }

        [HttpPost]
        public ActionResult<AddBrandResponse> AddBrand(AddBrandRequest request)
        {
            AddBrandResponse response = _brandService.Add(request);
            return CreatedAtAction(nameof(GetList), new { id = response.Id }, response); //201
        }
    }
}