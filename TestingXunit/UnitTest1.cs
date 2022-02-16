using Alba;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Xml;
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
           Assert.IsType<List<WeatherForecast>>(res.ReadAsJson<List<WeatherForecast>>());
        }
    }
}