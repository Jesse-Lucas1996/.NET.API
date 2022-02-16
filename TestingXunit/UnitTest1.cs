using System.Net;
using System.Threading.Tasks;
using Alba;
using Xunit;

namespace TestingXunit
{
    [CollectionDefinition("Scenarios")]
    public class UnitTest1 : IClassFixture<WebAppFixture>
    {
        public UnitTest1(WebAppFixture fixture)
        {
            _alba = fixture.AlbaHost;
        }
        private readonly IAlbaHost _alba;

        [Fact]
        public async Task TestingTask()
        {
            await _alba.Scenario(_ =>
            {
                _.Get.Url("/fake/okay");
                _.StatusCodeShouldBeOk();
            });
        }

        [Fact]
        public async Task Auth0GetTokenFail()
        {
            await _alba.Scenario(_ =>
            {
                _.Post.Url("/https://dev-cpt-j07e.au.auth0.com/oauth/token");
                _.StatusCodeShouldBe(HttpStatusCode.Unauthorized);
            });
        }
    }
}