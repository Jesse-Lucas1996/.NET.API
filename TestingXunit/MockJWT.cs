using System.Security.Claims;
using Alba.Security;
using Microsoft.IdentityModel.JsonWebTokens;
namespace TestingXunit;
public static class MockJwt
{
    public const string DefaultUser = "auth0|6205cf2103fae400710448d5";
    public const string Issuer = "https://dev-cpt-j07e.au.auth0.com";

    public static JwtSecurityStub Configuration()
        => new JwtSecurityStub()
            .With("iss", Issuer)
            .With("scope", "read:weather")
            .With(JwtRegisteredClaimNames.Email, "jessejlucas@hotmail.com")
            .With(ClaimTypes.NameIdentifier, DefaultUser);
}
