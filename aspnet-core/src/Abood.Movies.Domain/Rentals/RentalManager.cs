using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Abood.Movies.Rentals
{
    public class RentalManager : DomainService
    {
        private readonly IRepository<Rental, Guid> _rentalRepository;
        public RentalManager(IRepository<Rental, Guid> RentalRepository)
        {
            _rentalRepository = RentalRepository;
        }
        public async Task CheckMovieAvailabilityAsync(Guid movieId)
        {

            var activeRental = await _rentalRepository.FirstOrDefaultAsync(
                x => x.MovieId == movieId && !x.IsReturned);

            if (activeRental != null)
            {
                throw new BusinessException(MoviesDomainErrorCodes.MovieAlreadyRented);
            }
        }
        public async Task CheckCustomerRentalLimitAsync(Guid customerId)
        {
            var activeCustomerRentals = await _rentalRepository.CountAsync(
                x => x.CustomerId == customerId && !x.IsReturned);

            if (activeCustomerRentals >= MoviesConsts.MaxActiveRentalsPerCustomer)
            {
                throw new BusinessException(
                    MoviesDomainErrorCodes.CustomerRentalLimitExceeded);
            }
        }
        public Task CheckRentalDueDateAsync(DateTime dueDate)
        {
            if (dueDate.Date < DateTime.Today)
            {
                throw new BusinessException(
                    MoviesDomainErrorCodes.DueDateCannotBePast);
            }

            return Task.CompletedTask;
        }
        public Task CheckReturnMovieAsync(Rental rental)
        {
            if (rental.IsReturned)
            {
                throw new BusinessException(
                    MoviesDomainErrorCodes.RentalAlreadyReturned);
            }

            return Task.CompletedTask;
        }

       
    
    public async Task<Rental> CreateAsync(
    Guid customerId,
    Guid movieId,
    DateTime dueDate)
        {
            await CheckMovieAvailabilityAsync(movieId);
            await CheckCustomerRentalLimitAsync(customerId);
            await CheckRentalDueDateAsync(dueDate);

            return new Rental(
                GuidGenerator.Create(),
                customerId,
                movieId,
                Clock.Now,
                dueDate
            );
        }

    }
}
