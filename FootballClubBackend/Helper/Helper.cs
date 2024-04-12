using FootballClubBackend.Repository;
using FootballClubBackend.Service;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FootballClubBackend.Helper
{
    public class Helper
    {
        public static void AddScoped(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<PlayerService>();
            builder.Services.AddScoped<PlayerRepository>();

            builder.Services.AddScoped<PlayerStatisticService>();
            builder.Services.AddScoped<PlayerStatisticRepository>();

            builder.Services.AddScoped<MatchService>();
            builder.Services.AddScoped<MatchRepository>();

            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<UserRepository>();

            builder.Services.AddScoped<ArticleService>();
            builder.Services.AddScoped<ArticleRepository>();

            builder.Services.AddScoped<TableService>();
            builder.Services.AddScoped<TableRepository>();
        }
    }

    public class Authorizer
    {
        private const string SecretKey = "dh1jh32ujdk190AIJ0013kjklasdi910KAJ92j93K31Asdadtvzaj"; 
        private static readonly SymmetricSecurityKey SigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(SecretKey));
        public Authorizer() { }


        public static string GenerateToken(string username, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("your-secret-key-here-asdd1i920389jffh289fh98fh9hjoij");

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role),
            // Add additional claims as needed
        };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1), // Token expiration time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = "Issuer",
                Audience = "Audience"
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        /*
        public static string GenerateTokenBackup(string username,string role)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: new SigningCredentials(SigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = SigningKey,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero // Set to zero to ensure token hasn't expired
                }, out _);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string? ReadUsernameFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            if (jwtToken?.Claims != null)
            {
                var usernameClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub);
                return usernameClaim?.Value;
            }

            return null;
        }

        public static string ReadRoleFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            if (jwtToken?.Claims != null)
            {
                var roleClaims = jwtToken.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).First();
                return roleClaims;
            }

            return "";
        }

        public static bool CheckAuthorization(string? token,string role)
        {
            if (token == null)
                return false;
            if (ValidateToken(token) && ReadRoleFromToken(token).Equals(role))
                return true;
            return false;
        }*/
    }

    public class PasswordHasher
    {
        public static string HashPassword(string plainPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(plainPassword, BCrypt.Net.BCrypt.GenerateSalt());
        }

        public static bool VerifyPassword(string plainPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
        }
    }
}
