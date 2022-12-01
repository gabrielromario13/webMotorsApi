namespace WebMotors.Application.Models.Car
{
    public class CarModelBase
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public short ModelYear { get; set; }
        public short ManufactureYear { get; set; }
        public string Version { get; set; }
        public string Color { get; set; }
        public bool Armored { get; set; }
        public decimal Mileage { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
