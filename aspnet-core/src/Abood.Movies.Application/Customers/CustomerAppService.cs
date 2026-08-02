using Abood.Movies.Permissions;
using Abood.Movies.Rentals;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Abood.Movies.Customers;

public class CustomerAppService :
    ApplicationService,
    ICustomerAppService
{
    private readonly IRepository<Customer, Guid> _customerRepository;
    private readonly IRepository<Rental, Guid> _rentalRepository;

    public CustomerAppService(
        IRepository<Customer, Guid> customerRepository,
        IRepository<Rental, Guid> rentalRepository)
    {
        _customerRepository = customerRepository;
        _rentalRepository = rentalRepository;
    }


    [Authorize(MoviesPermissions.Customers.Default)]
    public async Task<CustomerDto> GetAsync(Guid id)
    {
        var customer = await _customerRepository.GetAsync(id);

        return ObjectMapper.Map<Customer, CustomerDto>(customer);
    }


    [Authorize(MoviesPermissions.Customers.Default)]
    public async Task<PagedResultDto<CustomerDto>> GetListAsync(
        PagedAndSortedResultRequestDto input)
    {
        var customers = await _customerRepository.GetListAsync();

        var items = ObjectMapper.Map<List<Customer>, List<CustomerDto>>(customers);

        return new PagedResultDto<CustomerDto>(
            items.Count,
            items
        );
    }


    [Authorize(MoviesPermissions.Customers.Create)]
    public async Task<CustomerDto> CreateAsync(
        CreateUpdateCustomerDto input)
    {
        var customer = new Customer(
            GuidGenerator.Create(),
            input.FullName,
            input.Email,
            input.PhoneNumber
        );

        await _customerRepository.InsertAsync(customer);

        return ObjectMapper.Map<Customer, CustomerDto>(customer);
    }


    [Authorize(MoviesPermissions.Customers.Edit)]
    public async Task<CustomerDto> UpdateAsync(
        Guid id,
        CreateUpdateCustomerDto input)
    {
        var customer = await _customerRepository.GetAsync(id);

        customer.SetFullName(input.FullName);
        customer.SetEmail(input.Email);
        customer.SetPhoneNumber(input.PhoneNumber);

        await _customerRepository.UpdateAsync(customer);

        return ObjectMapper.Map<Customer, CustomerDto>(customer);
    }


    [Authorize(MoviesPermissions.Customers.Delete)]
    public async Task DeleteAsync(Guid id)
    {
        var activeRental = await _rentalRepository.FirstOrDefaultAsync(
            x => x.CustomerId == id && !x.IsReturned
        );

        if (activeRental != null)
        {
            throw new BusinessException(
                MoviesDomainErrorCodes.CustomerHasActiveRentals
            );
        }

        await _customerRepository.DeleteAsync(id);
    }
}