using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace HotelRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class AuthController : ControllerBase
    {
        [HttpPost("token")]
        
        public ActionResult GetToken()
        {
            //secret key
            string seckey = "this_is_our_long_string_security_key_token_for_our_project";
            var symmetricsecuritykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(seckey));
            var signingCredentials = new SigningCredentials(symmetricsecuritykey, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                issuer: "sme.in",
                audience: "readers",
                expires: DateTime.Now.AddHours(1),
                signingCredentials: signingCredentials
                );
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));

        }
    }
}