using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Abood.Movies.Movies;

public interface IMovieRepository : IRepository<Movie, Guid>
{
    Task<Movie?> GetWithDirectorAsync(Guid id);
}