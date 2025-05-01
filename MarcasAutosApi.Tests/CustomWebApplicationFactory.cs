using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcasAutosApi.Tests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            // Necesario para que WebApplicationFactory encuentre el proyecto web fuera del directorio actual
            builder.UseContentRoot(@"..\MarcasAutosApi");

            return base.CreateHost(builder);
        }
    }
}
