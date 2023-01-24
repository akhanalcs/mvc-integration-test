using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using MyCoolApp.Data;

namespace MyCoolApp.IntegrationTests
{
    [TestClass]
    public class MyCoolAppBasicTests
    {
        private static WebApplicationFactory<Program> _factory;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            Console.WriteLine(testContext.TestName);
            //_factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => builder.UseEnvironment("Staging"));
            _factory = new CustomWebApplicationFactory<Program>();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _factory.Dispose();
        }

        [TestMethod]
        public async Task Should_Return_Success_Response_From_Controller()
        {
            // ARRANGE
            var client = _factory.CreateClient();

            // If I wanted to resolve some service:
            //using var scope = _factory.Services.CreateScope();
            //var scopedServices = scope.ServiceProvider;
            //var db = scopedServices.GetRequiredService<ApplicationDbContext>();

            // ACT
            var response = await client.GetAsync("/");

            // ASSERT
            Assert.IsNotNull(response);
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.AreEqual("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}