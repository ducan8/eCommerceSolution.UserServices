using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using eCommerce.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection; // tham chieu can thiet den IServiceCollection chi co trong project asp.net core, khong co trong project class library, can phai cai dat nuget package

namespace eCommerce.Core
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Extension method to add infrastructure services to the DI container
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection AddCore(this IServiceCollection service)
        {
            service.AddTransient<IUserService, UserService>();
            service.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
            //service.AddValidatorsFromAssemblyContaining<RegisterRequestValidator>();
            return service;
        }
    }
}
