using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace RestaurantReservation.API.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IConfiguration _configuration;

    public JwtTokenGenerator(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<string?> GenerateToken(AuthenticationRequestBody authenticationRequestBody)
    {
        if (!await ValidateUserCredentials(authenticationRequestBody))
            return null;

        var securityKey = new SymmetricSecurityKey(
            Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
        var signingCredentials = new SigningCredentials(
            securityKey, SecurityAlgorithms.HmacSha256);

        var claimsForToken = new List<Claim>();
        claimsForToken.Add(new Claim("sub", authenticationRequestBody.Username));

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _configuration["Authentication:Issuer"],
            audience: _configuration["Authentication:Audience"],
            claims: claimsForToken,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: signingCredentials);

        var token = new JwtSecurityTokenHandler()
            .WriteToken(jwtSecurityToken);

        return token;
    }

    private Task<bool> ValidateUserCredentials(AuthenticationRequestBody authenticationRequestBody)
    {
        // dummy validation
        if (authenticationRequestBody is { Username: "abc", Password: "xyz" })
            return Task.FromResult(true);
        return Task.FromResult(false);
    }
}