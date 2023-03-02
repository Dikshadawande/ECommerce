using Azure.Core;
using ECommerce.Core.Contract;
using ECommerce.Core.Domain.RequestModel;
using ECommerce.Infra.Contract;
using ECommerceContextt.Infra.Domain;
//using ECommerceContext.Infra.Domain;
using ECommerceContextt.Infra.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Services
{
    public  class UserService : IUserService
    {
        private readonly IUser _user;
        private readonly IConfiguration _config;

        public UserService(IUser userservice,IConfiguration configuration)
        {
            _user = userservice;
            _config = configuration;
        }

        public async Task<User> Add(UserRequestModel userRequestModel)
        {

            CreateHash(userRequestModel.password, out byte[] passwordHash, out byte[] passwordSalt);
            User u1=new User();
            u1.Id=userRequestModel.Id;
            u1.Name = userRequestModel.Name;
            u1.Role=userRequestModel.Role;
            u1.PasswordHash= passwordHash;
            u1.PasswordSalt= passwordSalt;
            
            //_user.AddUser(u1);

            return (await _user.AddUser(u1));

        }


        //login
        public async Task<string> Login(UserRequestModel request)
        {
            User u = await _user.UserLogin(request.Id);

            if (u.Name != request.Name)
            {
                return ("User Not Found");
            }
            if (!VerifyPasswordHash(request.password, u.PasswordHash, u.PasswordSalt))
            {
                return ("Wrong Password");
            }
            return (CreateToken(u));
        }

        public void CreateHash(string password, out byte[] PasswordHash, out byte[] PasswordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            }
        }
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Role,user.Role)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.
                GetBytes(_config.GetSection("AppSettings:Key").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

       
    }


}

