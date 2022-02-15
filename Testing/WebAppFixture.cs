using System.Threading.Tasks;
using Alba;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;
namespace Testing;

public class WebAppFixture : IAsyncLifetime
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

    [CollectionDefinition(nameof(WebAppCollection))]
    public class WebAppCollection : ICollectionFixture<WebAppFixture>
    {
    }

}