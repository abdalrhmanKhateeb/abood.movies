using Volo.Abp.Settings;

namespace Abood.Movies.Settings;

public class MoviesSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(MoviesSettings.MySetting1));
    }
}
