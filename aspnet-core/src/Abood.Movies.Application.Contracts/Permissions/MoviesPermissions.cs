namespace Abood.Movies.Permissions;

public static class MoviesPermissions
{
    public const string GroupName = "Movies";

    public static class Directors
    {
        public const string Default = GroupName + ".Directors";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
    public static class Movies
    {
        public const string Default = GroupName + ".Movies";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
    public static class Customers
    {
        public const string Default = GroupName + ".Customers";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
    public static class Rentals
    {
        public const string Default = GroupName + ".Rentals";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}
