using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Mapperly;

namespace Abood.Movies.Movies
{
    [Mapper]
    public partial class MovieToMovieDtoMapper
        : MapperBase<Movie, MovieDto>
    {
        [MapProperty(nameof(Movie.Director.Name), nameof(MovieDto.DirectorName))]
        public override partial MovieDto Map(Movie source);

        [MapProperty(nameof(Movie.Director.Name), nameof(MovieDto.DirectorName))]
        public override partial void Map(Movie source, MovieDto destination);
    }
}

