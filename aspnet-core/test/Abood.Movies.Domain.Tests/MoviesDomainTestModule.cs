using Volo.Abp.Modularity;

namespace Abood.Movies;

[DependsOn(
    typeof(MoviesDomainModule),
    typeof(MoviesTestBaseModule)
)]
public class MoviesDomainTestModule : AbpModule
{

}