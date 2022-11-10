using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Dto;
using NZWalks.NZWalks.Service.Contracts;
using NZWalks.Service.Contracts;

namespace ZWalks.API.Controllers
{
    [ApiController]
    [Route("controller")]

    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepo;
        private readonly IJwtTokenHandler _jwtTokenHadler;
        public AuthController(IUserRepository userRepo, IJwtTokenHandler jwtTokenHadler)
        {
            _userRepo = userRepo;
            _jwtTokenHadler = jwtTokenHadler;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync(LoginRequest loginRequest)
        {
            var user = await _userRepo.AuthenticateAsync(loginRequest.UserName, loginRequest.Password);
            if(user != null)
            {
               var token = await  _jwtTokenHadler.CreateTokenAsync(user);
               return Ok(token);
            }
            return BadRequest("Username and Password are not valid");
        }
    }
}