using Alba;
using SandboxAPI;
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
        public async Task Authorized()
        {
           var res = await _alba.Scenario(_ =>
            {
                _.Get.Url("/WeatherForecast");
                _.StatusCodeShouldBeOk();
            });
           Assert.IsType<WeatherForecast[]>(res.ReadAsJson<WeatherForecast[]>());
        }

        [Fact]
        public async Task Unauthorized()
        {
            var res = await _alba.Scenario(_ =>
            {
                _.RemoveRequestHeader("authorization");
                _.Get.Url("/WeatherForecast");
                _.StatusCodeShouldBe(401);
            });
        }
    }
}