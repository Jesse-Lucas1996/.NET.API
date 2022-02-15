using System.Security.Claims;
using Alba.Security;


namespace TestingXunit;

public static class MockJwt
{
    public const string DefaultUser = "auth0|5d4915f39b8dd50e6cf1c443";
    public const string UserName = "John Smith";
    public const string Issuer = "https://thisisarealendpoint.com/";

    public static JwtSecurityStub Configuration()
        => new JwtSecurityStub()
            .With(new("iss", Issuer))
            .With(new(ClaimTypes.NameIdentifier, DefaultUser))
            .With(new("John Smith", UserName))
            .With(new("scope", "read:weather"));
}
