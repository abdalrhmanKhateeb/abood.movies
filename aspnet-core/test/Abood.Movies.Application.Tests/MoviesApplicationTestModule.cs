using Volo.Abp.Modularity;

namespace Abood.Movies;

[DependsOn(
    typeof(MoviesApplicationModule),
    typeof(MoviesDomainTestModule)
)]
public class MoviesApplicationTestModule : AbpModule
{

}
