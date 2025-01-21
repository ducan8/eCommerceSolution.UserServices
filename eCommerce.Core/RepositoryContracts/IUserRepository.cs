using eCommerce.Core.Entities;

namespace eCommerce.Core.RepositoryContracts
{
    public interface IUserRepository
    {
        Task<AppUser?> AddUser(AppUser user); 
        Task<AppUser?> GetUserByEmailAndPassword(string? email, string? password);
    }
}
