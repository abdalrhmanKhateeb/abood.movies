using Abood.Movies.Directors;
using Abood.Movies.Movies;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace Abood.Movies;

[Mapper]
public partial class DirectorToDirectorDtoMapper
    : MapperBase<Director, DirectorDto>
{
    public override partial DirectorDto Map(Director source);

    public override partial void Map(Director source, DirectorDto destination);
}