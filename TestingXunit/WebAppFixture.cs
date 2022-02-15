using System;
using System.Threading.Tasks;
using Alba;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
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
                    s.AddAuthentication("Auth0");
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