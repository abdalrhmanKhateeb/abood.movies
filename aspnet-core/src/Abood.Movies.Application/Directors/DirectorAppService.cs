using Abood.Movies.Permissions;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Abood.Movies.Directors
{
    public class DirectorAppService :
     CrudAppService<
         Director,
         DirectorDto,
         Guid,
         PagedAndSortedResultRequestDto,
         CreateUpdateDirectorDto>,
     IDirectorAppService
    {
        public DirectorAppService(IRepository<Director, Guid> repository)
            : base(repository)
        {
            GetPolicyName = MoviesPermissions.Directors.Default;
            GetListPolicyName = MoviesPermissions.Directors.Default;
            CreatePolicyName = MoviesPermissions.Directors.Create;
            UpdatePolicyName = MoviesPermissions.Directors.Edit;
            DeletePolicyName = MoviesPermissions.Directors.Delete;
        }
    }
}