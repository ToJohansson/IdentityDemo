using Companies.API.Data;

namespace Tournamet.Api.Extensions;

public static class ApplicationBuilderExtensions
{

    public static async Task SeedDataAsync(this IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var services = scope.ServiceProvider;
            await SeedData.SeedDataAsync(services);
        }
    }

}
