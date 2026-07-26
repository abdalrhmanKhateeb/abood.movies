using System.Threading.Tasks;

namespace Abood.Movies.Data;

public interface IMoviesDbSchemaMigrator
{
    Task MigrateAsync();
}
