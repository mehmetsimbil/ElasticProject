using AutoMapper;
using Business.Abstract;
using Business.Requests.Brand;
using Business.Requests.Category;
using Business.Responses.Brand;
using Business.Responses.Category;
using DataAccess.Concrete.UnitOfWork;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public AddCategoryResponse Add(AddCategoryRequest request)
        {

            if (!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                throw new Exception("Hata: Kullanıcı kimlik doğrulaması başarısız. JWT token düzgün gönderilmemiş veya geçersiz.");
            }

            //foreach (var claim in _httpContextAccessor.HttpContext.User.Claims)
            //{
            //    Console.WriteLine($"Claim Type: {claim.Type}, Value: {claim.Value}");
            //}

            var roleClaim = _httpContextAccessor.HttpContext.User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.Role && c.Value == "Admin");

            if (roleClaim is null)
            {
                throw new Exception("Yetkiniz yok. 'Admin' rolü bulunamadı.");
            }

            var categoryToAdd = _mapper.Map<Category>(request);
            Category addedCategory = _unitOfWork.CategoryDal.Add(categoryToAdd);
            var response = _mapper.Map<AddCategoryResponse>(addedCategory);
            _unitOfWork.Save();

            return response;
        }

        public GetCategoryListResponse GetList(GetCategoryListRequest request)
        {
            IList<Category> categories = _unitOfWork.CategoryDal.GetList(predicate: a => a.IsDeleted == false);
            GetCategoryListResponse response = _mapper.Map<GetCategoryListResponse>(categories);
            return response;
        }
    }
}
