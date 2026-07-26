using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Mapperly;

namespace Abood.Movies.Directors
{
    [Mapper]
    public partial class DirectorToDirectorDtoMapper
    : MapperBase<Director, DirectorDto>
    {
        public override partial DirectorDto Map(Director source);

        public override partial void Map(Director source, DirectorDto destination);
    }
}
