using Xunit;

namespace Abood.Movies.EntityFrameworkCore;

[CollectionDefinition(MoviesTestConsts.CollectionDefinitionName)]
public class MoviesEntityFrameworkCoreCollection : ICollectionFixture<MoviesEntityFrameworkCoreFixture>
{

}
