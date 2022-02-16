using Alba.Security;
using Microsoft.IdentityModel.JsonWebTokens;
namespace TestingXunit;
public static class MockJwt
{
    public const string DefaultUser = "auth0|6205cf2103fae400710448d5";

    public static JwtSecurityStub Configuration()
        => new JwtSecurityStub()
            .With(JwtRegisteredClaimNames.Email, "jessejlucas@hotmail.com")
            .With(JwtRegisteredClaimNames.Name, DefaultUser)
            .With(JwtRegisteredClaimNames.Name,"Jesse Lucas");
}
