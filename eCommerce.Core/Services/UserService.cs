using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
        {
            AppUser? user = await _userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

            if (user == null) return null;

            
            return _mapper.Map<AuthenticationResponse>(user) with { Success = true, Token = "token"};
        }

        public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
        {
            AppUser user = new AppUser()
            {
                PersonName = registerRequest.PersonName,
                Email = registerRequest.Email,
                Password = registerRequest.Password,
                Gender = registerRequest.Gender.ToString(),

            };
            AppUser? newUser = await _userRepository.AddUser(user);

            if (newUser == null) return null;

            
            return _mapper.Map<AuthenticationResponse>(user) with { Success = true, Token = "token" };
        }
    }
}
