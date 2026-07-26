using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Abood.Movies.Data;

/* This is used if database provider does't define
 * IMoviesDbSchemaMigrator implementation.
 */
public class NullMoviesDbSchemaMigrator : IMoviesDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
