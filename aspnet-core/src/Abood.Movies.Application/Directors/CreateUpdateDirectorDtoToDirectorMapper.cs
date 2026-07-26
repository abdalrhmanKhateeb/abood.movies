using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Mapperly;

namespace Abood.Movies.Directors
{
    [Mapper]
    public partial class CreateUpdateDirectorDtoToDirectorMapper
     : TwoWayMapperBase<CreateUpdateDirectorDto, Director>
    {
        public override partial Director Map(CreateUpdateDirectorDto source);

        public override partial void Map(CreateUpdateDirectorDto source, Director destination);

        public override partial CreateUpdateDirectorDto ReverseMap(Director source);

        public override partial void ReverseMap(Director source, CreateUpdateDirectorDto destination);
    }
}
