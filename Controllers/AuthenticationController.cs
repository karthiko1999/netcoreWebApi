using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Repositories;

namespace StudentManagement.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHandler _tokenHandler;

        public AuthenticationController(IUserRepository userRepository,ITokenHandler TokenHandler)
        {
            this._userRepository = userRepository;
            _tokenHandler = TokenHandler;
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody]Models.DTOs.UserRequest userrequest)
        {
            // check user is Authenticate or Not
            var user = _userRepository.Authenticate(userrequest.UserName,userrequest.Password);

            if(user != null)
            {
                // Generate Token
                var token = _tokenHandler.CreateToken(user);
                 return Ok(token); 
            } 
            return BadRequest("UserName and Password is Invalid.....");
        }

    }
}