using MyHistory.Application.Common.Interfaces.Authentication;
using MyHistory.Application.Common.Interfaces.Generic;
using MyHistory.Application.Common.Interfaces.Persistence;
using MyHistory.Domain.Entities;
using MyHistory.Domain.Responses.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHistory.Application.Services.Authentication
{
    public interface IAutheService
    {
        Task<AuthenticationResponse> Register(string firstName,string LastName,string email, string password );
        AuthenticationResponse Login(string email, string password );
    }

    public class AuthenticationService : IAutheService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IJwtTokenGenerator _jwt;

        public AuthenticationService(IUnitOfWork unitOfWork, IJwtTokenGenerator jwt)
        {
            _unitOfWork = unitOfWork;
            _jwt = jwt;
        }

        //Change Authentication result for a auth response
        public AuthenticationResponse Login(string email, string password)
        {

            if (_unitOfWork.Users.GetUserByEmail(email) is not User user)
            {
                throw new Exception("Credentials are not correct");
            }

            if (user.Password != password)
            {
                throw new Exception("Invalid credentials");
            }
            var token = _jwt.GenerateToken(user);

            return  new AuthenticationResponse(
                user.Id,user.FirstName,user.LastName,user.Email,token);
        }

        public async Task<AuthenticationResponse> Register(string firstName, string LastName, string email, string password)
        {

            if (_unitOfWork.Users.GetUserByEmail(email) != null )
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

            await _unitOfWork.Users.AddAsync(user);


            var token = _jwt.GenerateToken(user);

            return new AuthenticationResponse(
                user.Id, user.FirstName, user.LastName, user.Email, token);
        }


    }
}
