namespace ASP_NET_12._Refactroing._Autorization.Auth;

public class JwtConfig
{
    public string Secret { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public int Expiration { get; set; }
}
