using Abood.Movies.Permissions;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Abood.Movies.Customers;

public class CustomerAppService :
    CrudAppService<
        Customer,
        CustomerDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateCustomerDto>,
    ICustomerAppService
{
    public CustomerAppService(
        IRepository<Customer, Guid> repository)
        : base(repository)
    {
        GetPolicyName = MoviesPermissions.Customers.Default;
        GetListPolicyName = MoviesPermissions.Customers.Default;
        CreatePolicyName = MoviesPermissions.Customers.Create;
        UpdatePolicyName = MoviesPermissions.Customers.Edit;
        DeletePolicyName = MoviesPermissions.Customers.Delete;
    }


    public override async Task<CustomerDto> CreateAsync(CreateUpdateCustomerDto input)
    {
        var customer = new Customer(
            GuidGenerator.Create(),
            input.FullName,
            input.Email,
            input.PhoneNumber
        );

        await Repository.InsertAsync(customer);

        return ObjectMapper.Map<Customer, CustomerDto>(customer);
    }


    public override async Task<CustomerDto> UpdateAsync(
        Guid id,
        CreateUpdateCustomerDto input)
    {
        var customer = await Repository.GetAsync(id);

        customer.SetFullName(input.FullName);
        customer.SetEmail(input.Email);
        customer.SetPhoneNumber(input.PhoneNumber);

        await Repository.UpdateAsync(customer);

        return ObjectMapper.Map<Customer, CustomerDto>(customer);
    }
}