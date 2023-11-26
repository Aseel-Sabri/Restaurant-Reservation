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

    /// <summary>
    /// Authenticates a user and generates a JWT token.
    /// </summary>
    /// <param name="authenticationRequestBody">The authentication request body.</param>
    /// <returns>
    ///     <para>200 OK if authentication is successful with the token in the Authorization header</para>
    ///     <para>401 Unauthorized if authentication fails</para>
    /// </returns>
    /// <response code="200">Authentication successful. Returns a JWT token in the Authorization header.</response>
    /// <response code="401">Authentication failed. Unauthorized access.</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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