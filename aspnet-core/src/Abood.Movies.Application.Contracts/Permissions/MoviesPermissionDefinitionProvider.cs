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
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MoviesResource>(name);
    }
}
