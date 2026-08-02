using Abood.Movies.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Abood.Movies.Permissions;

public class MoviesPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(MoviesPermissions.GroupName);
        var directorsPermission = myGroup.AddPermission(
    MoviesPermissions.Directors.Default,
    L("Permission:Directors")
);

        directorsPermission.AddChild(
            MoviesPermissions.Directors.Create,
            L("Permission:Directors.Create")
        );

        directorsPermission.AddChild(
            MoviesPermissions.Directors.Edit,
            L("Permission:Directors.Edit")
        );

        directorsPermission.AddChild(
            MoviesPermissions.Directors.Delete,
            L("Permission:Directors.Delete")
        );
        var customersPermission = myGroup.AddPermission(MoviesPermissions.Customers.Default);

        customersPermission.AddChild(MoviesPermissions.Customers.Create);

        customersPermission.AddChild(MoviesPermissions.Customers.Edit);

        customersPermission.AddChild(MoviesPermissions.Customers.Delete);

        var moviesPermission = myGroup.AddPermission(
    MoviesPermissions.Movies.Default,
    L("Permission:Movies")
);

        moviesPermission.AddChild(
            MoviesPermissions.Movies.Create,
            L("Permission:Movies.Create")
        );

        moviesPermission.AddChild(
            MoviesPermissions.Movies.Edit,
            L("Permission:Movies.Edit")
        );

        moviesPermission.AddChild(
            MoviesPermissions.Movies.Delete,
            L("Permission:Movies.Delete")
        );

        var rentalsPermission = myGroup.AddPermission(
    MoviesPermissions.Rentals.Default,
    L("Permission:Rentals")
);

        rentalsPermission.AddChild(
            MoviesPermissions.Rentals.Create,
            L("Permission:Rentals.Create")
        );

        rentalsPermission.AddChild(
            MoviesPermissions.Rentals.Edit,
            L("Permission:Rentals.Edit")
        );

        rentalsPermission.AddChild(
            MoviesPermissions.Rentals.Delete,
            L("Permission:Rentals.Delete")
        );
    }


    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MoviesResource>(name);
    }
}
