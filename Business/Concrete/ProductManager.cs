using AutoMapper;
using Business.Abstract;
using Business.Dtos.Product;
using Business.Requests.Product;
using Business.Responses.Product;
using DataAccess.Concrete.UnitOfWork;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Nest;
using System.Security.Claims;


namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IElasticClient _elasticClient;

        public ProductManager(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IElasticClient elasticClient)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _elasticClient = elasticClient;
        }

        public AddProductResponse Add(AddProductRequest request)
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

            var productToAdd = _mapper.Map<Product>(request);
            Product addedProduct = _unitOfWork.ProductDal.Add(productToAdd);
            var response = _mapper.Map<AddProductResponse>(addedProduct);
            _unitOfWork.Save();
            IndexProduct(addedProduct);
            return response;
        }

        public GetProductListResponse GetList(GetProductListRequest request)
        {
            IList<Product> products = _unitOfWork.ProductDal.GetList(predicate: a => a.IsDeleted == false);
            GetProductListResponse response = _mapper.Map<GetProductListResponse>(products);
            return response;
        }

        public void IndexProduct(Product product)
        {
            if (product == null)
            {
                Console.WriteLine("Product is null.");
                return;
            }

            var indexResponse = _elasticClient.IndexDocument(product);

        }

        public GetProductListResponse GetListFromElastic(GetProductListRequest request)
        {
           
            var searchResponse = _elasticClient.Search<Product>(s => s
                .Query(q => q.MatchAll())  
            );

            if (!searchResponse.IsValid || searchResponse.Hits.Count == 0)
            {
                return new GetProductListResponse();  
            }

            
            var productList = searchResponse.Documents.ToList();

          
            var items = _mapper.Map<List<ProductListItemDto>>(productList);

            return new GetProductListResponse(items);  
        }


    }
}
