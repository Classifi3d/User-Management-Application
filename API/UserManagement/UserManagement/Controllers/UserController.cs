using BusinessLogicLayer.Service;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UserManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        private string CreateToken(Guid userId)
        {
            List<Claim> claims = new List<Claim>
            {
                //new Claim(ClaimTypes.Email,user.Email)
                new Claim(ClaimTypes.NameIdentifier,userId.ToString())
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));
            var cred = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(6),
                signingCredentials: cred
            );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            
            return jwt;
        }


        [HttpGet]
        public async Task<IActionResult> GetUsersAsync() {
            var users = await _userService.GetUsersAsync();
            if(users!=null)
            {
                return Ok(users);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetUserById")]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute] Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddUserAsync(AddUser addUser)
        {
            var user = await _userService.AddUserAsync(addUser);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UpdateUser updateUser)
        {
            var response = await _userService.UpdateUserAsync(updateUser);
            if (response == true)
            {
                return Ok(true);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [ActionName("DeleteById")]
        public async Task<IActionResult> DeleteUserAsync(Guid id)
        {
            var response = await _userService.DeleteUserAsync(id);
            if (response == true)
            {
                return Ok(true);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        [Route("login")]
        [ActionName("UserLogin")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] LoginUser loginUser)
        {
            Guid response = await _userService.LoginAsync(loginUser);
            if(response != Guid.Empty)
            {
                string token = CreateToken(response).ToString();
                return Ok(token);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        [Route("loginold")]
        [ActionName("UserLoginOld")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsyncOld([FromBody] LoginUser loginUser)
        {
            Guid response = await _userService.LoginAsync(loginUser);
            if (response != Guid.Empty)
            {
                return Ok(response);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        [Route("CountryLink")]
        [ActionName("UserCountryLink")]
        public async Task<IActionResult> LinkUserCountries([FromBody] UserCountries userCountries)
        {
            var response = await _userService.LinkUserCountries(userCountries);
            return Ok(response);
        }

    }
}
