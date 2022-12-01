using WebMotors.Application.Models.User;
using WebMotors.Application.Utils;
using WebMotors.Domain.Model;

namespace WebMotors.Application.Adapter
{
    public static class UserAdapter
    {
        public static User ToDomain(UserRequestModel param) =>
            param == default ? null : new User
            (
                param.Name,
                param.Email,
                param.Login,
                HashUtils.HashPassword(param.Password),
                param.BirthDate,
                param.CPF,
                param.Cellphone,
                param.CEP
            );

        public static UserResponseModel FromDomain(User param) =>
            param == default ? null : new UserResponseModel
            {
                Id = param.Id,
                Name = param.Name,
                Email = param.Email,
                Login = param.Login,
                BirthDate = param.BirthDate,
                CPF = param.CPF,
                Cellphone = param.Cellphone,
                CEP = param.CEP
            };
    }
}
