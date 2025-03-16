using DatabaseFirstEFCore.Model;
using DatabaseFirstEFCore.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace DatabaseFirstEFCore.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly JwtOptions _jwtOptions;
        private readonly IPatientService _patientService;

        public AuthService(IPatientService patientService, IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
            _patientService = patientService;
        }

        public async Task<string> LogIn(LoginDTO userDetails)
        {
            var result = string.Empty;
            try
            {
                var employee = await _patientService.GetPatientDetailByEmail(userDetails.Email);
                if (employee is null)
                {
                    return result = "Email Doesn't Exist !!";
                }
                if (employee.Password != userDetails.Password)
                {
                    return result = "Passowrd Doesn't Exist!";
                }
                var jwtKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtOptions.Key));
                var credential = new SigningCredentials(jwtKey, SecurityAlgorithms.HmacSha256);
                List<Claim> claims = new List<Claim>() { new Claim("Email", userDetails.Email) };
                var securityToken = new JwtSecurityToken(_jwtOptions.Key, _jwtOptions.Issuer, claims, expires: DateTime.Now.AddHours(1), signingCredentials: credential);
                var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
                var myString = "Bearer" + " " + token;
                result = JsonSerializer.Serialize(myString);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
    }
}
