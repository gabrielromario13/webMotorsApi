using WebMotors.Application.Adapter;
using WebMotors.Application.Models.Car;
using WebMotors.Domain.Interfaces.Repository;

namespace WebMotors.Application.Services.Car
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<CarResponseModel> Create(CarRequestModel request)
        {
            var car = CarAdapter.ToDomain(request);

            await _carRepository.Create(car);

            return CarAdapter.FromDomain(car);
        }

        public async Task<IEnumerable<CarResponseModel>> GetAll()
        {
            var cars = await _carRepository.GetAll();

            return cars.Select(car => CarAdapter.FromDomain(car));
        }

        public async Task<CarResponseModel> GetById(int id)
        {
            var car = await _carRepository.GetById(id);

            return CarAdapter.FromDomain(car);
        }

        public async Task<bool> Update(int id, CarRequestModel request)
        {
            var car = await _carRepository.GetById(id);

            if (car == null)
                return false;

            await _carRepository.Update(CarAdapter.ToDomain(request));
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            if (await _carRepository.ExistingEntity(id))
                return false;

            await _carRepository.Delete(id);
            return true;
        }
    }
}
