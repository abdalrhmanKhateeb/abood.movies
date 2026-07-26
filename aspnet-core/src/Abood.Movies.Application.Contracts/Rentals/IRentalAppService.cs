using Abood.Movies.Customers;
using Abood.Movies.Movies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Abood.Movies.Rentals
{
    public interface IRentalAppService :
        ICrudAppService<
            RentalDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateRentalDto>
    {
        Task<List<CustomerDto>> GetCustomersAsync();

        Task<List<MovieDto>> GetMoviesAsync();

        Task ReturnMovieAsync(Guid rentalId);

        
    }
}
