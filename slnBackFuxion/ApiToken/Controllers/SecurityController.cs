using ApiFuxion.Custom;
using ApiToken.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiToken.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {

        private IToken _token;

        public SecurityController(IToken token)
        {
            _token = token;
        }

        [HttpPost]
        public IActionResult Login([FromBody] User oUser)
        {

            if(oUser.CodUser == "admin" && oUser.Password == "123456")
            {
                var token = _token.CreateToken(oUser.CodUser);

                return Ok(new
                {
                    token
                });

            }

            return BadRequest(new { message = "Credenciales incorrectas" });
            
        }
    }
}
