using ClassLibrary.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ClassLibrary.Extensions;

public static class MigrationManager
{
    public static IHost MigrateDatabase(this IHost host)
    {
        using var scope = host.Services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<PatramDbContext>();

        //var a = context.Database.GetAppliedMigrations();
        //context.GetInfrastructure().GetService<IMigrator>().Migrate(@"20230206113205_Clear_All_Data");

        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }

        return host;
    }
}
