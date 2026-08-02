using Abood.Movies.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Abood.Movies.Rentals;

public class EfCoreRentalRepository :
    EfCoreRepository<MoviesDbContext, Rental, Guid>,
    IRentalRepository
{
    public EfCoreRentalRepository(
        IDbContextProvider<MoviesDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }


    public async Task<Rental?> GetWithCustomerAndMovieAsync(Guid id)
    {
        var dbSet = await GetDbSetAsync();

        return await dbSet
            .Include(x => x.Customer)
            .Include(x => x.Movie)
            .FirstOrDefaultAsync(x => x.Id == id);
    }


    public async Task<List<Rental>> GetListWithCustomerAndMovieAsync()
    {
        var dbSet = await GetDbSetAsync();

        return await dbSet
            .Include(x => x.Customer)
            .Include(x => x.Movie)
            .ToListAsync();
    }
}