using Abood.Movies.EntityFrameworkCore;
using Shouldly;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Abood.Movies.Rentals;

public class RentalManagerTests : MoviesEntityFrameworkCoreTestBase
{
    private readonly RentalManager _RentalManager;
    private readonly IRepository<Rental, Guid> _rentalRepository;

    public RentalManagerTests()
    {
        _RentalManager = GetRequiredService<RentalManager>();
        _rentalRepository = GetRequiredService<IRepository<Rental, Guid>>();
    }


    [Fact]
    public async Task Should_Not_Allow_Renting_Already_Rented_Movie()
    {
        var movieId = Guid.NewGuid();

        await _rentalRepository.InsertAsync(
            new Rental(
                Guid.NewGuid(),
                Guid.NewGuid(),
                movieId,
                DateTime.Now,
                DateTime.Now.AddDays(5)
            )
        );


        var exception = await Should.ThrowAsync<BusinessException>(
            async () =>
            {
                await _RentalManager.CheckMovieAvailabilityAsync(movieId);
            });


        exception.Code.ShouldBe(
            MoviesDomainErrorCodes.MovieAlreadyRented);
    }


    [Fact]
    public async Task Should_Not_Allow_Customer_More_Than_Two_Active_Rentals()
    {
        var customerId = Guid.NewGuid();

        await _rentalRepository.InsertAsync(
            new Rental(
                Guid.NewGuid(),
                customerId,
                Guid.NewGuid(),
                DateTime.Now,
                DateTime.Now.AddDays(5)
            )
        );

        await _rentalRepository.InsertAsync(
            new Rental(
                Guid.NewGuid(),
                customerId,
                Guid.NewGuid(),
                DateTime.Now,
                DateTime.Now.AddDays(5)
            )
        );


        var exception = await Should.ThrowAsync<BusinessException>(
            async () =>
            {
                await _RentalManager.CheckCustomerRentalLimitAsync(customerId);
            });


        exception.Code.ShouldBe(
            MoviesDomainErrorCodes.CustomerRentalLimitExceeded);
    }


    [Fact]
    public async Task Should_Not_Allow_Past_Due_Date()
    {
        var exception = Should.Throw<BusinessException>(
            () =>
            {
                _RentalManager
                    .CheckRentalDueDateAsync(
                        DateTime.Today.AddDays(-1))
                    .GetAwaiter()
                    .GetResult();
            });


        exception.Code.ShouldBe(
            MoviesDomainErrorCodes.DueDateCannotBePast);
    }


    [Fact]
    public async Task Should_Not_Return_Already_Returned_Rental()
    {
        var rental = new Rental(
            Guid.NewGuid(),
            Guid.NewGuid(),
            Guid.NewGuid(),
            DateTime.Now,
            DateTime.Now.AddDays(5)
        );

        rental.ReturnMovie();


        var exception = await Should.ThrowAsync<BusinessException>(
            async () =>
            {
                await _RentalManager.CheckReturnMovieAsync(rental);
            });


        exception.Code.ShouldBe(
            MoviesDomainErrorCodes.RentalAlreadyReturned);
    }
}