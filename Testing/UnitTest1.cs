using System.Net;
using System.Threading.Tasks;
using Alba;
using Xunit;

namespace Testing
{
    [CollectionDefinition(nameof(WebAppFixture.WebAppCollection))]
    public class UnitTest1
    {
        private readonly IAlbaHost _host;
        public UnitTest1(WebAppFixture fixture)
        {
            _host = fixture.AlbaHost;
        }
        

        [Fact]
        public async Task Test1()
        {
           await _host.Scenario(_ =>
            {
                _.Get.Url("/fake/okay");
                _.StatusCodeShouldBeOk();
            });
        }
    }
}