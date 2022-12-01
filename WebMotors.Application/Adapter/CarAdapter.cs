using WebMotors.Application.Models.Car;
using WebMotors.Domain.Model;

namespace WebMotors.Application.Adapter
{
    public static class CarAdapter
    {
        public static Car ToDomain(CarRequestModel param) =>
            param == default ? null : new Car
            (
                param.Brand,
                param.Model,
                param.ModelYear,
                param.ManufactureYear,
                param.Version,
                param.Color,
                param.Armored,
                param.Mileage,
                param.Description,
                param.Price
                
            );

        public static CarResponseModel FromDomain(Car param) =>
            param == default ? null : new CarResponseModel
            {
                Brand = param.Brand,
                Model = param.Model,
                ModelYear = param.ModelYear,
                ManufactureYear = param.ManufactureYear,
                Version = param.Version,
                Color = param.Color,
                Armored = param.Armored,
                Mileage = param.Mileage,
                Description = param.Description,
                Price = param.Price
            };
    }
}
