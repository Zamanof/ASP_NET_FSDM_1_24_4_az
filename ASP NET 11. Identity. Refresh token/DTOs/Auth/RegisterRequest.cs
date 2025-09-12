using System.ComponentModel.DataAnnotations;

namespace ASP_NET_11._Identity._Refresh_token.DTOs.Auth;

public class RegisterRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(8)]
    public string Password { get; set; }
}
