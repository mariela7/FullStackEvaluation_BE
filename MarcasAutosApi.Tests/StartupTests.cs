//using Microsoft.VisualStudio.TestPlatform.TestHost;
//using System.Threading.Tasks;
//using Xunit;
//using Microsoft.AspNetCore.Mvc.Testing;

//namespace MarcasAutosApi.Tests
//{
//    public class StartupTests : IClassFixture<WebApplicationFactory<Program>>
//    {
//        [Fact]
//        public async Task GetMarcas_Endpoint_ReturnsSuccess()
//        {
//            var factory = new CustomWebApplicationFactory();
//            var client = factory.CreateClient();
//            var response = await client.GetAsync("/api/MarcasAutos");
//            response.EnsureSuccessStatusCode();
//        }
//    }
//}
