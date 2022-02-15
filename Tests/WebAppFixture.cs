/*using Alba;
using Xunit;
namespace Tests
{
    public class WebAppFixture
    {
        public IAlbaHost AlbaHost = null!;
        public async Task InitializeAsync()
        {
            AlbaHost = await Alba.AlbaHost.For<Program>(builder =>
            {

            });
        }
        public async Task DisposeAsync()
        {
            await AlbaHost.DisposeAsync();
        }

    }
}*/