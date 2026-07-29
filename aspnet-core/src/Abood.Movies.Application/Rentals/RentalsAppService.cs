using Abood.Movies.Customers;
using Abood.Movies.Movies;
using Abood.Movies.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;


namespace Abood.Movies.Rentals;

public class RentalAppService :
    ApplicationService,
    IRentalAppService
{
    private readonly IRentalRepository _rentalRepository;
   
    private readonly RentalManager _rentalManager;


    public RentalAppService(
        IRentalRepository rentalRepository,
     
        RentalManager rentalManager)
    {
        _rentalRepository = rentalRepository;
 
        _rentalManager = rentalManager;
    }


    [Authorize(MoviesPermissions.Rentals.Create)]
    public async Task<RentalDto> CreateAsync(
        CreateUpdateRentalDto input)
    {
        var rental = await _rentalManager.CreateAsync(
            input.CustomerId,
            input.MovieId,
            input.DueDate
        );

        await _rentalRepository.InsertAsync(rental);

        var createdRental =
            await _rentalRepository.GetWithCustomerAndMovieAsync(rental.Id);

        return ObjectMapper.Map<Rental, RentalDto>(createdRental);
    }


    [Authorize(MoviesPermissions.Rentals.Default)]
    public async Task<RentalDto> GetAsync(Guid id)
    {
        var rental = await _rentalRepository
            .GetWithCustomerAndMovieAsync(id);

        if (rental == null)
        {
            throw new EntityNotFoundException(
                typeof(Rental),
                id);
        }

        return ObjectMapper.Map<Rental, RentalDto>(rental);
    }


    [Authorize(MoviesPermissions.Rentals.Default)]
    public async Task<PagedResultDto<RentalDto>> GetListAsync(
        PagedAndSortedResultRequestDto input)
    {
        var rentals = await _rentalRepository
            .GetListWithCustomerAndMovieAsync();

        var items = ObjectMapper
            .Map<List<Rental>, List<RentalDto>>(rentals);

        return new PagedResultDto<RentalDto>(
            items.Count,
            items
        );
    }


    [Authorize(MoviesPermissions.Rentals.Edit)]
    public async Task<RentalDto> UpdateAsync(
        Guid id,
        CreateUpdateRentalDto input)
    {
        var rental = await _rentalRepository.GetAsync(id);

        rental.SetDueDate(input.DueDate);

        await _rentalRepository.UpdateAsync(rental);

        return ObjectMapper.Map<Rental, RentalDto>(rental);
    }


    [Authorize(MoviesPermissions.Rentals.Edit)]
    public async Task ReturnMovieAsync(Guid rentalId)
    {
        

        var rental = await _rentalRepository.GetWithCustomerAndMovieAsync(rentalId);

        if (rental == null)
        {
            throw new EntityNotFoundException(
                typeof(Rental),
                rentalId);
        }

        await _rentalManager.CheckReturnMovieAsync(rental);

        rental.ReturnMovie();

        await _rentalRepository.UpdateAsync(rental);
    }


    [Authorize(MoviesPermissions.Rentals.Delete)]
    public async Task DeleteAsync(Guid id)
    {
        await _rentalRepository.DeleteAsync(id);
    }

}