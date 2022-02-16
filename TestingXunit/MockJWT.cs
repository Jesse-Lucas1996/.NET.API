using System.Security.Claims;
using Alba.Security;
using Microsoft.IdentityModel.JsonWebTokens;

namespace TestingXunit;

public static class MockJwt
{
    public const string DefaultUser = "auth0|5d4915f39b8dd50e6cf1c443";

    public static JwtSecurityStub Configuration()
        => new JwtSecurityStub()
            .With(JwtRegisteredClaimNames.Email, "jessejlucas@hotmail.com")
            .With(JwtRegisteredClaimNames.Name, DefaultUser)
            .With(JwtRegisteredClaimNames.GivenName, "Jesse Lucas");
}
