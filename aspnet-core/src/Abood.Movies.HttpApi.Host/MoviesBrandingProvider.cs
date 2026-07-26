using Microsoft.Extensions.Localization;
using Abood.Movies.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Abood.Movies;

[Dependency(ReplaceServices = true)]
public class MoviesBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<MoviesResource> _localizer;

    public MoviesBrandingProvider(IStringLocalizer<MoviesResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
