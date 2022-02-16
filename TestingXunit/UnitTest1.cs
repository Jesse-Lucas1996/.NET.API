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
        public async Task Unauthorized()
        {
            await _alba.Scenario(_ =>
            {
                _.Get.Url("/WeatherForecast");
                _.StatusCodeShouldBe(200);
            });
        }
    }
}