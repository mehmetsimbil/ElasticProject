using AutoMapper;
using Business.Abstract;
using Business.Requests.Brand;
using Business.Responses.Brand;
using DataAccess.Concrete.UnitOfWork;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BrandManager(IMapper mapper, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
        }

        public AddBrandResponse Add(AddBrandRequest request)
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

            var brandToAdd = _mapper.Map<Brand>(request);
            Brand addedBrand = _unitOfWork.BrandDal.Add(brandToAdd);
            _unitOfWork.Save();
            var response = _mapper.Map<AddBrandResponse>(addedBrand);
            return response;
        }
        public GetBrandListResponse GetList(GetBrandListRequest request)
        {
            IList<Brand> brands = _unitOfWork.BrandDal.GetList(predicate: a => a.IsDeleted == false);
            GetBrandListResponse response = _mapper.Map<GetBrandListResponse>(brands);
            return response;
        }
    }
}
