using DAL.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DAL.Extensions;

public static class DatabaseExtensions
{
    public static async Task<IHost> EnsureDeletedAsync(this IHost app, CancellationToken cancellationToken = default)
    {
        using var scope = app.Services.CreateScope();
        var scopedContext = scope.ServiceProvider.GetRequiredService<BookStoreDbContext>();
        await scopedContext.Database.EnsureDeletedAsync(cancellationToken);

        return app;
    }
    
    public static async Task<IHost> EnsureCreatedAsync(this IHost app, CancellationToken cancellationToken = default)
    {
        using var scope = app.Services.CreateScope();
        var scopedContext = scope.ServiceProvider.GetRequiredService<BookStoreDbContext>();
        await scopedContext.Database.EnsureCreatedAsync(cancellationToken);

        return app;
    }
}