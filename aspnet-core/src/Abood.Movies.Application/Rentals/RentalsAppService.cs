using Abood.Movies.Customers;
using Abood.Movies.Movies;
using Abood.Movies.Permissions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Nito.AsyncEx;

namespace Abood.Movies.Rentals
{
    public class RentalAppService :
        CrudAppService<
            Rental,
            RentalDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateRentalDto>,
        IRentalAppService
    {
        private readonly IRepository<Customer, Guid> _customerRepository;
        private readonly IMovieRepository _movieRepository;

        private readonly RentalManager _rentalManager; public RentalAppService(
      IRepository<Rental, Guid> repository,
    IRepository<Customer, Guid> customerRepository,
    IMovieRepository movieRepository,
    RentalManager rentalManager)
             : base(repository)
        {
            _customerRepository = customerRepository;
            _movieRepository = movieRepository;
            _rentalManager = rentalManager;

            GetPolicyName = MoviesPermissions.Rentals.Default;
            GetListPolicyName = MoviesPermissions.Rentals.Default;
            CreatePolicyName = MoviesPermissions.Rentals.Create;
            UpdatePolicyName = MoviesPermissions.Rentals.Edit;
            DeletePolicyName = MoviesPermissions.Rentals.Delete;
        }

        public async Task<List<CustomerDto>> GetCustomersAsync()
        {
            var customers = await _customerRepository.GetListAsync();

            return ObjectMapper.Map<List<Customer>, List<CustomerDto>>(customers);
        }
        public async Task<List<MovieDto>> GetMoviesAsync()
        {
            var movies = await _movieRepository.GetListAsync();

            return ObjectMapper.Map<List<Movie>, List<MovieDto>>(movies);
        }
        public override async Task<RentalDto> CreateAsync(CreateUpdateRentalDto input)
        {
            await _rentalManager.CheckMovieAvailabilityAsync(input.MovieId);

            await _rentalManager.CheckCustomerRentalLimitAsync(input.CustomerId);

            await _rentalManager.CheckRentalDueDateAsync(input.DueDate);

            var rental = ObjectMapper.Map<CreateUpdateRentalDto, Rental>(input);

            rental.RentalDate = DateTime.Now;
            rental.IsReturned = false;
            rental.ReturnDate = null;

            await Repository.InsertAsync(rental);

            return ObjectMapper.Map<Rental, RentalDto>(rental);
        }

        public async Task ReturnMovieAsync(Guid rentalId)
        {
            var rental = await Repository.GetAsync(rentalId);

            await _rentalManager.CheckReturnMovieAsync(rental);

            rental.IsReturned = true;
            rental.ReturnDate = DateTime.Now;

            await Repository.UpdateAsync(rental);
        }

    }
}