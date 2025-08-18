using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace WebApi.Tests
{
    public class ItemsApiTests : IClassFixture<WebApplicationFactory<WebApi.Startup>>
    {
        private readonly WebApplicationFactory<WebApi.Startup> _factory;
        public ItemsApiTests(WebApplicationFactory<WebApi.Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_ReturnsOk()
        {
            var client = _factory.CreateClient();
            var res = await client.GetAsync("/api/items");
            Assert.Equal(HttpStatusCode.OK, res.StatusCode);
        }
    }
}