using Abood.Movies.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Abood.Movies.Movies;

public class EfCoreMovieRepository :
    EfCoreRepository<MoviesDbContext, Movie, Guid>,
    IMovieRepository
{
    public EfCoreMovieRepository(
        IDbContextProvider<MoviesDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }

    public async Task<Movie?> GetWithDirectorAsync(Guid id)
    {
        var dbSet = await GetDbSetAsync();

        return await dbSet
            .Include(x => x.Director)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<List<Movie>> GetListWithDirectorAsync()
    {
        return await (await GetDbSetAsync())
            .Include(x => x.Director)
            .ToListAsync();
    }
}