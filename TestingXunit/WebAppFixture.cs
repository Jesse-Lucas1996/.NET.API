using Alba;
using Xunit;

namespace TestingXunit
{
    public class WebAppFixture : IAsyncLifetime
    {
        public IAlbaHost AlbaHost = null!;

        public async Task InitializeAsync()
        {
            AlbaHost = await Alba.AlbaHost.For<Program>(builder =>
            {
                builder.ConfigureServices(s =>
                {
                 
                });
            }, MockJwt.Configuration());
        }

        public async Task DisposeAsync()
        {
            await AlbaHost.DisposeAsync();

        }

        [CollectionDefinition("Scenarios")]
        public class WebAppCollection : ICollectionFixture<WebAppFixture>
        {
        }

    }
}