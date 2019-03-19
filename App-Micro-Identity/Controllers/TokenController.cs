using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using App_Micro_Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace App_Micro_Identity.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        protected IConfiguration configuration;
        public TokenController(IConfiguration config)
        {
            configuration = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Request(TokenRequestModel model)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, "管理员")
                , new Claim(ClaimTypes.Role, "admin")
            };


            var expires = DateTime.Now.AddDays(Convert.ToDouble(configuration["JwtSettings:ExpiresDay"]));
            var token = new JwtSecurityToken(
                issuer: configuration["JwtSettings:Issuer"],
                audience: configuration["JwtSettings:Audience"],
                claims: claims,
                notBefore: DateTime.Now,
                expires: expires,
                signingCredentials: creds);

            return Ok(new { Token = new JwtSecurityTokenHandler().WriteToken(token), Expires = expires.ToString("yyyy-MM-dd HH:mm:ss") });
        }
    }
}