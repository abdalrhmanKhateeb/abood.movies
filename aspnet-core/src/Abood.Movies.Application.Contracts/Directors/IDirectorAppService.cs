using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;


namespace Abood.Movies.Directors
{
    public interface IDirectorAppService :
     ICrudAppService<
         DirectorDto,
         Guid,
         PagedAndSortedResultRequestDto,
         CreateUpdateDirectorDto>
    {




    }
}