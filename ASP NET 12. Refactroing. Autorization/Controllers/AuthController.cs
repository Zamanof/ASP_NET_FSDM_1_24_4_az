using ASP_NET_12._Refactroing._Autorization.DTOs.Auth;
using ASP_NET_12._Refactroing._Autorization.Models;
using ASP_NET_12._Refactroing._Autorization.Services.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace ASP_NET_12._Refactroing._Autorization.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{

    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IJwtService _jwtService;

    public AuthController(
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        IJwtService jwtService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtService = jwtService;
    }


    /// <summary>
    /// Login
    /// </summary>
    /// <returns></returns>
    [HttpPost("login")]
    public async Task<ActionResult<AuthTokenDTO>> Login([FromBody] LoginRequest request)
    {

        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null) return Unauthorized();

        var canSignIn = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        if (!canSignIn.Succeeded) return Unauthorized();

        var roles = await _userManager.GetRolesAsync(user);

        var userClaims = await _userManager.GetClaimsAsync(user);        

        var accessToken = _jwtService.GenerateSecurityToken(user.Id, user.Email!, roles, userClaims);

        var refreshToken = Guid.NewGuid().ToString("N").ToLower();

        user.RefreshToken = refreshToken;

        await _userManager.UpdateAsync(user);


        return new AuthTokenDTO
        {
            Token = accessToken,
            RefreshToken = refreshToken
        };
    }
    /// <summary>
    /// Register
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("register")]
    public async Task<ActionResult<AuthTokenDTO>> Register([FromBody] RegisterRequest request)
    {
        var exisitingUser = await _userManager.FindByEmailAsync(request.Email);

        if (exisitingUser is not null) return Conflict("User already exsist!");

        var user = new AppUser
        {
            Email = request.Email,
            UserName = request.Email,
            RefreshToken = Guid.NewGuid().ToString("N").ToLower()
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded) return BadRequest(result.Errors);        

        return await GenerateToken(user);
    }

    /// <summary>
    /// Refresh
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("refresh")]
    public async Task<ActionResult<AuthTokenDTO>> Refresh([FromBody] RefreshTokenRequest request)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == request.RefreshToken);
        if (user is null) return Unauthorized();

        return await GenerateToken(user);
    }


    private async Task<AuthTokenDTO> GenerateToken(AppUser user)
    {
        var roles = await _userManager.GetRolesAsync(user);

        var userClaims = await _userManager.GetClaimsAsync(user);

        var accessToken = _jwtService.GenerateSecurityToken(user.Id, user.Email!, roles, userClaims);

        var refreshToken = Guid.NewGuid().ToString("N").ToLower();
        user.RefreshToken = refreshToken;

        await _userManager.UpdateAsync(user);

        return new AuthTokenDTO
        {
            Token = accessToken,
            RefreshToken = refreshToken
        };

    }

}

// Identity:
// AAD, OAuth2, Cognito, KeyCloack, B2C, ...
// Microsoft Identity
