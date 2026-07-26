using Abood.Movies.Customers;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Mapperly;

namespace Abood.Movies.Customers
{
    [Mapper]
    public partial class CreateUpdateCustomerDtoToCustomerMapper
    : MapperBase<CreateUpdateCustomerDto, Customer>
    {
        public override partial Customer Map(CreateUpdateCustomerDto source);

        public override partial void Map(CreateUpdateCustomerDto source, Customer destination);
    }
}