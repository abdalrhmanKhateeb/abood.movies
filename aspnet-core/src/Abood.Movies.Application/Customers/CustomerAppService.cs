using Abood.Movies.Permissions;
using Abood.Movies.Rentals;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Abood.Movies.Customers
{
    public class CustomerAppService :
        CrudAppService<
            Customer,
            CustomerDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateCustomerDto>,
        ICustomerAppService
    {
        private readonly IRepository<Rental, Guid> _rentalRepository;

        public CustomerAppService(
            IRepository<Customer, Guid> repository,
            IRepository<Rental, Guid> rentalRepository)
            : base(repository)
        {
            _rentalRepository = rentalRepository;

            GetPolicyName = MoviesPermissions.Customers.Default;
            GetListPolicyName = MoviesPermissions.Customers.Default;
            CreatePolicyName = MoviesPermissions.Customers.Create;
            UpdatePolicyName = MoviesPermissions.Customers.Edit;
            DeletePolicyName = MoviesPermissions.Customers.Delete;
        }

        public override async Task DeleteAsync(Guid id)
        {
            var activeRental = await _rentalRepository.FirstOrDefaultAsync(
                x => x.CustomerId == id && !x.IsReturned);

            if (activeRental != null)
            {
                throw new BusinessException(
                    MoviesDomainErrorCodes.CustomerHasActiveRentals);
            }

            await base.DeleteAsync(id);
        }
    }
}