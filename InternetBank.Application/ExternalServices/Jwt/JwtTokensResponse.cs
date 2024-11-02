namespace InternetBank.Application.ExternalServices.Jwt
{
    // public record JwtTokensResponse(string AccessToken);
    public class JwtTokensResponse
    {
        public string? AccessToken { get; set; }
    }
}