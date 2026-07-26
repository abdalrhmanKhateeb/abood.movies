namespace Abood.Movies;

public static class MoviesDomainErrorCodes
{

        public const string MovieAlreadyRented = "Movies:MovieAlreadyRented";

    public const string CustomerRentalLimitExceeded = "movie:CustomerHasMoreThanTwoActiveRents";

    public const string DueDateCannotBePast = "movie:DateIsInPast";

    public const string RentalAlreadyReturned ="Movies:RentalAlreadyReturned";

    public const string CustomerHasActiveRentals ="Movies:CustomerHasActiveRentals";


}

