using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCoolApp.IntegrationTests
{
    public class CustomWebApplicationFactory<TProgram>
        : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            // Use whichever
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Staging"); // Works for: Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") in Program.cs
            builder.UseEnvironment("Staging"); // Works for builder.Environment.EnvironmentName in Program.cs
        }
    }
}
