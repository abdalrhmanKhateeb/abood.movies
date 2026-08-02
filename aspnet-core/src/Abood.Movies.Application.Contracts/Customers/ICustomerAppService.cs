using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Abood.Movies.Customers
{
    public interface ICustomerAppService
    {
        Task<CustomerDto> GetAsync(Guid id);

        Task<PagedResultDto<CustomerDto>> GetListAsync(
            PagedAndSortedResultRequestDto input);

        Task<CustomerDto> CreateAsync(CreateUpdateCustomerDto input);

        Task<CustomerDto> UpdateAsync(Guid id, CreateUpdateCustomerDto input);

        Task DeleteAsync(Guid id);
    }
}