using Abood.Movies.Samples;
using Xunit;

namespace Abood.Movies.EntityFrameworkCore.Applications;

[Collection(MoviesTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<MoviesEntityFrameworkCoreTestModule>
{

}
