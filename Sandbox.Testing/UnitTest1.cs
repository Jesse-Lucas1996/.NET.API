using System.Threading.Tasks;
using Alba;
using Xunit;

namespace Sandbox.Testing
{
    [CollectionDefinition("scenarios")]
    public class UnitTest1 : IClassFixture<WebAppFixture>
    {
        private readonly IAlbaHost _host;

        public UnitTest1(WebAppFixture fixture)
        {
            _host = fixture.AlbaHost;
        }

        [Fact]
        public Task Test1()
        {
            return _host.Scenario(_ =>
            {
                _.Get.Url("/fake/okay");
                _.StatusCodeShouldBeOk();
            });
        }
    }
}