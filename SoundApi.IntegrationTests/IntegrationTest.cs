using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using SoundApi.Data;
using Microsoft.EntityFrameworkCore;


namespace SoundApi.IntegrationTests
{
    public class IntegrationTest
    {
        protected readonly HttpClient TestClient;
        public IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(AppDbContext));
                        services.AddDbContext<AppDbContext>(options =>
                        {
                            options.UseInMemoryDatabase("TestDb");
                        });
                    });
                });

            TestClient = appFactory.CreateClient();

        }
    }
}
