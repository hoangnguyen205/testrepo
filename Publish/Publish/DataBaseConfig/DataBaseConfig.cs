using Microsoft.EntityFrameworkCore;
using Publish.Service;
using System.Diagnostics;
using System.Security.Claims;

namespace Publish.Util
{
    public static class DataBaseConfig
    {
        public static void ConfigDB(this WebApplication app)
        {
            using (var serviceScope = app.Services.GetService<IServiceScopeFactory>()!.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ResourceContext>();
                context.Database.EnsureCreated();
            }
        }

    }
}
