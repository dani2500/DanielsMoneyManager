using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using DanielsMoneyManagerApi.Models;
using DanielsMoneyManagerApi.Dtos;
using DanielsMoneyManagerApi.Helpers;
using DanielsMoneyManagerApi.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using static Dapper.SqlMapper;

namespace DanielsMoneyManagerApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepo;
        private readonly JwtService _jwtService;


        public AuthController(JwtService jwtService, IUserRepository userRepo) 
        {
            _jwtService = jwtService;
            _userRepo = userRepo;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register(RegisterDto dto)
        {
            User user;

            string userName = dto.UserName;
            string userEmail = dto.UserEmail;
            string userPass = BCrypt.Net.BCrypt.HashPassword(dto.UserPassword);


            user = _userRepo.GetUserByEmail(userEmail);
            if (user != null)
            {
                return Conflict();
            }

            user = _userRepo.InsertUser(userName, userPass, userEmail);
            string jwt = _jwtService.Generate(user.User_ID, out int jwtLifeTimeMs);

            LoginResponseDto response = new LoginResponseDto
            {
                Jwt = jwt,
                UserName = userName,
                UserEmail = userEmail,
                UserId = user.User_ID,
                JwtLifeTimeMs = jwtLifeTimeMs
            };

            return Created($"Success", response); //TODO use conflict method if already exist
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(LoginRequestDto dto)
        {
            string userEmail = dto.UserEmail;
            string userPass = dto.UserPassword;

            User user = _userRepo.GetUserByEmail(userEmail);

            if (user == null)
            {
                return Unauthorized(new { message = "Email is not registered" });
            }

            bool isValidPass = BCrypt.Net.BCrypt.Verify(userPass, user.User_Password);

            if (!isValidPass)
            {
                return Unauthorized(new { message = "Invalid password" });
            }

            var jwt = _jwtService.Generate(user.User_ID, out int jwtLifeTimeMs);

            LoginResponseDto response = new LoginResponseDto
            {
                Jwt = jwt,
                UserName = user.User_Name,
                UserEmail = userEmail,
                UserId = user.User_ID,
                JwtLifeTimeMs = jwtLifeTimeMs
            };

            var res = Ok(response);
            return res;
        }

        [HttpGet("user")]
        [Authorize]
        public IActionResult User()
        {
            int userId = _jwtService.GetUserId(HttpContext.User);
            var user = _userRepo.GetUserById(userId);

            return Ok(user);
        }
    }
}
