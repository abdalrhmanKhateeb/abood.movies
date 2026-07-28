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
        [MapProperty(
            nameof(Rental.Customer.FullName),
            nameof(RentalDto.CustomerName))]
        [MapProperty(
            nameof(Rental.Movie.Title),
            nameof(RentalDto.MovieTitle))]
        public override partial RentalDto Map(Rental source);


        [MapProperty(
            nameof(Rental.Customer.FullName),
            nameof(RentalDto.CustomerName))]
        [MapProperty(
            nameof(Rental.Movie.Title),
            nameof(RentalDto.MovieTitle))]
        public override partial void Map(
            Rental source,
            RentalDto destination);
    }
}