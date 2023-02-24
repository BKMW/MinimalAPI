using JwtAuthManager.Models;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtAuthManager
{
    public class JwtTokenHandler
    {
        public const string JWT_SECURITY_KEY = "yPkjhhYTGbFGG25K85JHnugffg847fdghHng";
        private const int JWT_TOKEN_VALIDITY_MINS = 20;
        private readonly List<UserAccount> _userAccountList;
        public JwtTokenHandler()
        {
            _userAccountList = new List<UserAccount>
             {
                 new UserAccount {UserName = "admin", Password = "123123", Role = "Admin" },
                 new UserAccount {UserName = "user", Password = "123123", Role = "User" },

            };
        }

        public AuthResponse? GenerateJwtToken(AuthRequest authRequest)
        {
            if (string.IsNullOrWhiteSpace(authRequest.UserName) || string.IsNullOrWhiteSpace(authRequest.Password))
                return null;
            /*Validation*/
            var userAccount = _userAccountList.Where(x => x.UserName == authRequest.UserName && x.Password == authRequest.Password)
                .FirstOrDefault();
            if (userAccount == null) return null;
            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, userAccount.UserName),
                new Claim(ClaimTypes.Role, userAccount.Role),
                // For Ocelot
                new Claim("Role", userAccount.Role),

            });

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature
                );

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signingCredentials
            };

            var jwtsecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken= jwtsecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtsecurityTokenHandler.WriteToken(securityToken);
            return new AuthResponse
            {
                UserName = userAccount.UserName,
                JwtToken = token,
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds
            };

        }
    }
}
