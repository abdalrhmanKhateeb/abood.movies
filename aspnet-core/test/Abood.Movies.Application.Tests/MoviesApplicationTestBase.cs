using Volo.Abp.Modularity;

namespace Abood.Movies;

public abstract class MoviesApplicationTestBase<TStartupModule> : MoviesTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
