using Volo.Abp.Modularity;

namespace Abood.Movies;

/* Inherit from this class for your domain layer tests. */
public abstract class MoviesDomainTestBase<TStartupModule> : MoviesTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
