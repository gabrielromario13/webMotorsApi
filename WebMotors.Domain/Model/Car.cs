using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebMotors.Domain.Model
{
    public class Car : BaseEntity
    {
        [Required]
        [StringLength(30)]
        public string Brand { get; private set; }

        [Required]
        [StringLength(30)]
        public string Model { get; private set; }

        [Required]
        public short ModelYear { get; private set; }

        [Required]
        public short ManufactureYear { get; private set; }

        [Required]
        [StringLength(30)]
        public string Version { get; private set; }

        [Required]
        [StringLength(30)]
        public string Color { get; private set; }

        [Required]
        public bool Armored { get; private set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Mileage { get; private set; }

        [StringLength(255)]
        public string Description { get; private set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; private set; }

        public int UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; }

        public Car()
        {

        }

        public Car(string brand, string model, short modelYear, short manufactureYear, string version, string color, bool armored, decimal mileage, string description, decimal price)
        {
            Brand = brand;
            Model = model;
            ModelYear = modelYear;
            ManufactureYear = manufactureYear;
            Version = version;
            Color = color;
            Armored = armored;
            Mileage = mileage;
            Description = description;
            Price = price;
        }
    }
}
