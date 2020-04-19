using Mara_Carona.BLL;
using Mara_Carona.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Mara_Carona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IUserBLL _userBLL;


        public LoginController(IConfiguration config, IUserBLL userBLL)
        {
            _config = config;
            _userBLL = userBLL;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]UserDTO login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);
            var tokenString = string.Empty;

            if (user != null)
            {
                tokenString = GenerateJSONWebToken(user);
                response = Ok(new { Token = tokenString, Id = user.Id, Name = user.username, Email = user.email});
            }

            return response;
        }

        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              signingCredentials: credentials);
            userInfo.Token = new JwtSecurityTokenHandler().WriteToken(token);
            _userBLL.updateUser(userInfo);
            return userInfo.Token;
        }

        private dynamic AuthenticateUser(UserDTO login)
        {
          var user = _userBLL.GetUserByEmail(login.Email);
            if (user == null)
            {
                return null;
            }
            if (user.password == login.Password)
            {
                return user;
            }
            return null;
        }
    }
}
