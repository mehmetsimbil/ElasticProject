using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.UnitOfWork;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Core.Utilities.Security.JWT;
using Elasticsearch.Net;
using Nest;

namespace Business.DependencyResolvers
{
    public static class ServiceCollectionBusinessExtension
    {
        public static IServiceCollection AddBusinessService(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services
                .AddScoped<IBrandService,BrandManager>()
                .AddScoped<IBrandDal, EfBrandDal>()
                .AddScoped<ICategoryService, CategoryManager>()
                .AddScoped<ICategoryDal,EfCategoryDal>()
                .AddScoped<IProductService, ProductManager>()
                .AddScoped<IProductDal,EfProductDal>()
                .AddScoped<IUserService, UserManager>()
                .AddScoped<IUserDal,EfUserDal>()
                .AddScoped<IRoleDal,EfRoleDal>()
                .AddScoped<IUserRoleDal,EfUserRoleDal>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<ITokenHelper,JwtTokenHelper>()
                .AddAutoMapper(Assembly.GetExecutingAssembly());


            services.AddDbContext<ProjectContext>(
              options => options.UseSqlServer(configuration.GetConnectionString("LastProjectConnectionString")));

            var pool = new SingleNodeConnectionPool(new Uri(configuration["Elastic:Url"]!));
            var settings = new ConnectionSettings(pool).DefaultIndex("products");
            var client = new ElasticClient(settings);
            services.AddSingleton<IElasticClient>(client);


            return services;
        }
    }
}
