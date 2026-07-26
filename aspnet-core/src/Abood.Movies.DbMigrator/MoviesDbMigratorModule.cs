using Abood.Movies.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Abood.Movies.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(MoviesEntityFrameworkCoreModule),
    typeof(MoviesApplicationContractsModule)
    )]
public class MoviesDbMigratorModule : AbpModule
{
}
