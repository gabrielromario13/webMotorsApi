using WebMotors.Application.Adapter;
using WebMotors.Application.Models.User;
using WebMotors.Domain.Interfaces.Repository;

namespace WebMotors.Application.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponseModel> Create(UserRequestModel request)
        {
            if (await _userRepository.ExistingLogin(request.Login))
                return null;

            var user = UserAdapter.ToDomain(request);

            await _userRepository.Create(user);

            return UserAdapter.FromDomain(user);
        }

        public async Task<IEnumerable<UserResponseModel>> GetAll()
        {
            var users = await _userRepository.GetAll();

            return users.Select(user => UserAdapter.FromDomain(user));
        }

        public async Task<UserResponseModel> GetById(int id)
        {
            var user = await _userRepository.GetById(id);

            return UserAdapter.FromDomain(user);
        }

        public async Task<bool> Update(int id, UserRequestModel request)
        {
            var user = await _userRepository.GetById(id);

            if (user == null)
                return false;

            user.Update(request.Name, request.Email, request.Login, request.Password, request.BirthDate, request.CPF, request.Cellphone, request.CEP);

            await _userRepository.Update(user);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            if (!await _userRepository.ExistingEntity(id))
                return false;

            await _userRepository.Delete(id);
            return true;
        }
    }
}
