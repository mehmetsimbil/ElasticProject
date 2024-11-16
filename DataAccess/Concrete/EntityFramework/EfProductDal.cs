using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using Nest;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfRepositoryBase<Product, ProjectContext>, IProductDal
    {
        private readonly IElasticClient _elasticClient;
        public EfProductDal(ProjectContext context, IElasticClient elasticClient) : base(context)
        {
            _elasticClient = elasticClient;
        }

       
        public void IndexProduct(Product product)
        {
            
            var indexResponse = _elasticClient.IndexDocument(product);
            if (!indexResponse.IsValid)
            {
                Console.WriteLine("Error indexing product: " + indexResponse.OriginalException.Message);
            }
        }
 
        public List<Product> GetList()
        {
            
            var searchResponse = _elasticClient.Search<Product>(s => s
                .Query(q => q
                    .MatchAll()  
                )
            );

            if (!searchResponse.IsValid || searchResponse.Hits.Count == 0)
            {
                return new List<Product>();  
            }

            return searchResponse.Documents.ToList();  
        }

    }
}