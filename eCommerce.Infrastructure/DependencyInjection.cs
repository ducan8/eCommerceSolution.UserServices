using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection; // tham chieu can thiet den IServiceCollection chi co trong project asp.net core, khong co trong project class library, can phai cai dat nuget package

namespace eCommerce.Infrastructure
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Extension method to add infrastructure services to the DI container
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection service) 
        {
            service.AddSingleton<IUserRepository, UserRepository>();
            service.AddTransient<DapperDbContext>();
            return service;
        }
    }
}
