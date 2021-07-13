using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(WebShop.Areas.Identity.IdentityHostingStartup))]
namespace WebShop.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => { });
        }
    }
}