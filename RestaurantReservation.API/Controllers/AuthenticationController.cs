using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Authentication;

namespace RestaurantReservation.API.Controllers;

[AllowAnonymous]
[ApiController]
[Route("/api/authenticate")]
public class AuthenticationController : ControllerBase
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationController(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    [HttpPost]
    public async Task<ActionResult> Authenticate(AuthenticationRequestBody authenticationRequestBody)
    {
        var token = await _jwtTokenGenerator.GenerateToken(authenticationRequestBody);
        if (token is null)
            return Unauthorized();

        Response.Headers.Add("Authorization", $"Bearer {token}");
        return Ok();
    }
}