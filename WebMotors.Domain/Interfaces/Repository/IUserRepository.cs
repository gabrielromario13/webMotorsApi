using WebMotors.Domain.Interfaces.Repositories;
using WebMotors.Domain.Model;

namespace WebMotors.Domain.Interfaces.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<bool> ExistingLogin(string login);
    }
}
