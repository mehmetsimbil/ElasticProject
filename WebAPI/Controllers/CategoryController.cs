using Business.Abstract;
using Business.Requests.Category;
using Business.Responses.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public ActionResult<AddCategoryResponse> AddCategory(AddCategoryRequest request) {

            AddCategoryResponse response = _categoryService.Add(request);
            return CreatedAtAction(nameof(GetList), response); //201

        }

        [HttpGet]
        public GetCategoryListResponse GetList([FromQuery]GetCategoryListRequest request)
        {
            GetCategoryListResponse response = _categoryService.GetList(request);
            return response;
        }
    }
}
