namespace Abood.Movies;

public static class MoviesDomainErrorCodes
{

    public const string MovieAlreadyRented = "Movies:MovieAlreadyRented";
    public const string CustomerRentalLimitExceeded = "Movies:CustomerRentalLimitExceeded";
    public const string DueDateCannotBePast = "Movies:DueDateCannotBePast";
    public const string RentalAlreadyReturned = "Movies:RentalAlreadyReturned";
    public const string CustomerHasActiveRentals = "Movies:CustomerHasActiveRentals";
    public const string InvalidPrice = "Movies:InvalidPrice";
    public const string MovieHasActiveRentals = "Movies:MovieHasActiveRentals";

}

