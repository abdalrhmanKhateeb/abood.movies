using Abood.Movies.Customers;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Mapperly;

namespace Abood.Movies.Customers
{

    [Mapper]
    public partial class CustomerToCustomerDtoMapper
        : MapperBase<Customer, CustomerDto>
    {
        public override partial CustomerDto Map(Customer source);

        public override partial void Map(Customer source, CustomerDto destination);
    }
}