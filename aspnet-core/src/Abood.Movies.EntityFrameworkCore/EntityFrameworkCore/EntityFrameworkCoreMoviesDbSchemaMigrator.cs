using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Abood.Movies.Data;
using Volo.Abp.DependencyInjection;

namespace Abood.Movies.EntityFrameworkCore;

public class EntityFrameworkCoreMoviesDbSchemaMigrator
    : IMoviesDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreMoviesDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the MoviesDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<MoviesDbContext>()
            .Database
            .MigrateAsync();
    }
}
