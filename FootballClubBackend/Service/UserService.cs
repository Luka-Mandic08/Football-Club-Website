using FootballClubBackend.Model;
using FootballClubBackend.Model.DTO;
using FootballClubBackend.Repository;

namespace FootballClubBackend.Service
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string? Login(Login dto)
        {
            return _userRepository.Login(dto.Email, dto.Password);
        }

        public bool Register(Register dto,string role)
        {
            return _userRepository.Create(new User(dto,role));
        }
    }
}
