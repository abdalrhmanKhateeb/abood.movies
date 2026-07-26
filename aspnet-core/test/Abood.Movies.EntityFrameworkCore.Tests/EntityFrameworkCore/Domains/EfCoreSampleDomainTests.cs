using Abood.Movies.Samples;
using Xunit;

namespace Abood.Movies.EntityFrameworkCore.Domains;

[Collection(MoviesTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<MoviesEntityFrameworkCoreTestModule>
{

}
