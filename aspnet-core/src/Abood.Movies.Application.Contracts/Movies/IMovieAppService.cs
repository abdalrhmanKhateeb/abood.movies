using Abood.Movies.Directors;
using Abood.Movies.Directors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;


namespace Abood.Movies.Movies
{

    public interface IMovieAppService :
 ICrudAppService<
     MovieDto,
     Guid,
     PagedAndSortedResultRequestDto,
     CreateUpdateMovieDto>
    {
        Task<List<DirectorDto>> GetDirectorsAsync();

    }

    }


