using ApplicationAuthentication.Abstraction;
using ApplicationDatabaseModels;
using ApplicationDomainCore.Abstraction;
using ApplicationDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriveLicenseApp.Controllers
{

    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        private readonly IRepository<User> _userRepository = default;
        private readonly IJwtAuthenticationManager _authenticationManager = default;


        public SignInController(IRepository<User> userRepository, IJwtAuthenticationManager authenticationManager)
        {
            _userRepository = userRepository;
            _authenticationManager = authenticationManager;
            _authenticationManager.SetUserRepo(userRepository);
        }


        // POST api/<SignInController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserAuthDto value)
        {
            var token = await _authenticationManager.AuthenticateAsync(value);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { bearerToken = token.Item1, Id = token.Item2 });
        }
    }
}
