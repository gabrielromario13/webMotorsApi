using WebMotors.Domain.Model;

namespace WebMotors.Domain.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task Create(TEntity entity);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task Update(TEntity entity);
        Task Delete(int id);
        Task<bool> ExistingEntity(int id);
    }
}
