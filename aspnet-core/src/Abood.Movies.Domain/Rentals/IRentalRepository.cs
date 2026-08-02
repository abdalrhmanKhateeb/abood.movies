using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Abood.Movies.Rentals
{
    public interface IRentalRepository : IRepository<Rental, Guid>
    {
        Task<Rental?> GetWithCustomerAndMovieAsync(Guid id);

        Task<List<Rental>> GetListWithCustomerAndMovieAsync();
    }
}
