using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Mapperly;

namespace Abood.Movies.Rentals
{
    [Mapper]
    public partial class CreateUpdateRentalDtoToRentalMapper
     : MapperBase<CreateUpdateRentalDto, Rental>
    {
        public override partial Rental Map(CreateUpdateRentalDto source);

        public override partial void Map(CreateUpdateRentalDto source, Rental destination);
    }
}