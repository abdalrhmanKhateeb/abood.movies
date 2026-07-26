using Abood.Movies.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Abood.Movies.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class MoviesController : AbpControllerBase
{
    protected MoviesController()
    {
        LocalizationResource = typeof(MoviesResource);
    }
}
