using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Mapperly;

namespace Abood.Movies.Rentals
{
    [Mapper]
    public partial class RentalToRentalDtoMapper
     : MapperBase<Rental, RentalDto>
    {
        public override partial RentalDto Map(Rental source);

        public override partial void Map(Rental source, RentalDto destination);
    }
}