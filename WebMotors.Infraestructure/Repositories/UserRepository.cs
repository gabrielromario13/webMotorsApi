using Microsoft.EntityFrameworkCore;
using WebMotors.Domain.Interfaces.Repository;
using WebMotors.Domain.Model;
using WebMotors.Infraestructure.Context;

namespace WebMotors.Infraestructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> ExistingLogin(string login) =>
            await _dbContext.Set<User>().AsNoTracking().AnyAsync(u => u.Login == login);
    }
}
