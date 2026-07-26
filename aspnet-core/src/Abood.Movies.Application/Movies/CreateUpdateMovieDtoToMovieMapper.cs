using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Mapperly;

namespace Abood.Movies.Movies
{
    [Mapper]
    public partial class CreateUpdateMovieDtoToMovieMapper
     : TwoWayMapperBase<CreateUpdateMovieDto, Movie>
    {
        public override partial Movie Map(CreateUpdateMovieDto source);

        public override partial void Map(CreateUpdateMovieDto source, Movie destination);

        public override partial CreateUpdateMovieDto ReverseMap(Movie source);

        public override partial void ReverseMap(Movie source, CreateUpdateMovieDto destination);
    }
}