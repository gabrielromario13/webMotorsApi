using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebMotors.Domain.Model
{
    public class User : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; private set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Login { get; private set; }

        [Required]
        [StringLength(100)]
        public string Password { get; private set; }

        [Required]
        public DateTime BirthDate { get; private set; }

        [Required]
        [StringLength(20)]
        public string CPF { get; private set; }

        [Required]
        [StringLength(20)]
        public string Cellphone { get; private set; }

        [Required]
        [StringLength(20)]
        public string CEP { get; private set; }

        [JsonIgnore]
        public ICollection<Car> Cars { get; set; }

        public User()
        {

        }

        public User(string name, string email, string login, string password, DateTime birthDate, string cpf, string cellphone, string cep)
        {
            Name = name;
            Email = email;
            Login = login;
            Password = password;
            BirthDate = birthDate;
            CPF = cpf;
            Cellphone = cellphone;
            CEP = cep;
        }

        public void Update(string name, string email, string login, string password, DateTime birthDate, string cpf, string cellphone, string cep)
        {
            Name = name;
            Email = email;
            Login = login;
            Password = password;
            BirthDate = birthDate;
            CPF = cpf;
            Cellphone = cellphone;
            CEP = cep;
        }
    }
}
