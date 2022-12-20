using MyHistory.Application.Common.Interfaces.Authentication;
using MyHistory.Application.Common.Interfaces.Persistence;
using MyHistory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHistory.Application.Services.Authentication
{
    public interface IAutheService
    {
        AuthenticationResult Register(string firstName,string LastName,string email, string password );
        AuthenticationResult Login(string email, string password );
    }

    public class AuthenticationService : IAutheService
    {
        private readonly IUserRepository _user;

        private readonly IJwtTokenGenerator _jwt;

        public AuthenticationService(IUserRepository user, IJwtTokenGenerator jwt)
        {
            _user = user;
            _jwt = jwt;
        }

        public AuthenticationResult Login(string email, string password)
        {

            if (_user.GetUserByEmail(email) is not User user)
            {
                throw new Exception("Credentials are not correct");
            }

            if (user.Password != password)
            {
                throw new Exception("Invalid credentials");
            }
            var token = _jwt.GenerateToken(user);

            return  new AuthenticationResult(
                user,token);
        }

        public AuthenticationResult Register(string firstName, string LastName, string email, string password)
        {

            if (_user.GetUserByEmail(email) != null )
            {
                throw new Exception("User with given email already exists");
            }

            var user = new User()
            {
                FirstName = firstName,
                Email = email,
                Password = password,
                LastName = LastName
            };

            _user.Add(user);


            var token = _jwt.GenerateToken(user);

            return new AuthenticationResult(user,token);
        }


    }
}
