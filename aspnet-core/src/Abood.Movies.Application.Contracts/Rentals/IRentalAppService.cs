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
    public interface IRentalAppService : IApplicationService
    {
        Task<RentalDto> CreateAsync(CreateUpdateRentalDto input);

        Task<RentalDto> GetAsync(Guid id);

        Task<PagedResultDto<RentalDto>> GetListAsync(
            PagedAndSortedResultRequestDto input);

        Task<RentalDto> UpdateAsync(
            Guid id,
            CreateUpdateRentalDto input);

        Task ReturnMovieAsync(Guid rentalId);

        Task DeleteAsync(Guid id);
    }
}
