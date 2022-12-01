using WebMotors.Domain.Interfaces.Repository;
using WebMotors.Domain.Model;
using WebMotors.Infraestructure.Context;

namespace WebMotors.Infraestructure.Repositories
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository(AppDbContext context) : base(context)
        {
        }
    }
}
