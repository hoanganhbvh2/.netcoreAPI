using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SE1811.model;
using static SE1811.model.LoginModel;

namespace SE1811.Controllers

{
 
    [Route("api/jwt")]
    [ApiController]
    public class JWTController :ControllerBase
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        private readonly IConfiguration _config;

        public JWTController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("private")]
        [Authorize]
        public IActionResult PrivateAPI()
        {
            var list = new[]
            {
                new { Code = 1, Name = "This end point is restricted " },
                new { Code = 2, Name = "You need to login to see this" }
            }.ToList();

            return Ok(list);
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (model.Username == "admin" && model.Password == "admin")
            {
                var token = GenerateJwtToken(model.Username);

                return Ok(new { accessToken = token });
            }
            return Unauthorized("Invalid username or password");
        }
        private string GenerateJwtToken(string username)
        {
            var jwtSettings = _config.GetSection("jwt");
            var secretKey = jwtSettings["secret"];
            var issuer = jwtSettings["issuer"];
            var audience = jwtSettings["audience"];

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(5), // hoặc đọc từ jwtSettings["accessTokenExpiration"]
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    

        [HttpGet("public")]
        public IActionResult ap1()
        {
            var list = new[]
            {
                new { Code = 1, Name = "This end point can be accessed by Public" },
                new { Code = 2, Name = "Whatever" }
                }.ToList();

            return Ok(list);
        }
        [HttpGet("test")]
        public void test() {
            Console.WriteLine(_config.GetSection("jwt"));
        }

    }
}
