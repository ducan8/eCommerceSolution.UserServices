using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly DapperDbContext _dbCotext;

        public UserRepository(DapperDbContext dbCotext)
        {
            _dbCotext = dbCotext;
        }

        public async Task<AppUser?> AddUser(AppUser user)
        {
            //generate a new unique userId
            user.UserId = Guid.NewGuid();

            //SQL 
            string query = "Insert into public.\"Users\"(\"UserId\", \"Email\", \"PersonName\", \"Gender\", \"Password\") values(@UserId, @Email, @PersonName, @Gender, @Password)";

            int rowCountAffected = await _dbCotext.DbConnection.ExecuteAsync(query, user);

            if (rowCountAffected > 0)
             {
                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task<AppUser?> GetUserByEmailAndPassword(string? email, string? password)
        {

            string query = "select * from public. \"Users\" where \"Email\"=@Email and \"Password\"=@Password";
            var parameters = new { Email = email, Password = password };

            AppUser? user = await _dbCotext.DbConnection.QueryFirstOrDefaultAsync<AppUser>(query, parameters);

            return user;

        }
    }
}
