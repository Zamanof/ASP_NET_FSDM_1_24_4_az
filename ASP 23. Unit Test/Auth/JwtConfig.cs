namespace ASP_23._Unit_Test.Auth;

public class JwtConfig
{
    public string Secret {  get; set; } = string.Empty;
    public string Issuer {  get; set; } = string.Empty;
    public string Audience {  get; set; } = string.Empty;
    public int Expiration {  get; set; }
}
