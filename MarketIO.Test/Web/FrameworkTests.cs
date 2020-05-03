using MarketIO.MVC;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

namespace MarketIO.Test.Web
{
    [TestFixture]
    class FrameworkTests
    {
        private readonly HttpClient _client;

        public FrameworkTests()
        {
            var server = new TestServer(new WebHostBuilder().UseEnvironment("Development").UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [Test]
        public async Task Default_Web_Request_To_Return_OK()
        {
            var response = await _client.GetAsync("/");
            var responseString = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
        }
    }
}
