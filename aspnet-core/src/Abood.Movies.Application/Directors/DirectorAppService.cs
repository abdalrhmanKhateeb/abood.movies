using Abood.Movies.Permissions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
        public DirectorAppService(
            IRepository<Director, Guid> repository)
            : base(repository)
        {
            GetPolicyName = MoviesPermissions.Directors.Default;
            GetListPolicyName = MoviesPermissions.Directors.Default;
            CreatePolicyName = MoviesPermissions.Directors.Create;
            UpdatePolicyName = MoviesPermissions.Directors.Edit;
            DeletePolicyName = MoviesPermissions.Directors.Delete;
        }


        public override async Task<DirectorDto> CreateAsync(CreateUpdateDirectorDto input)
        {
            var director = new Director(
                GuidGenerator.Create(),
                input.Name,
                input.Nationality
            );

            await Repository.InsertAsync(director);

            return ObjectMapper.Map<Director, DirectorDto>(director);
        }


        public override async Task<DirectorDto> UpdateAsync(
            Guid id,
            CreateUpdateDirectorDto input)
        {
            var director = await Repository.GetAsync(id);

            director.SetName(input.Name);
            director.SetNationality(input.Nationality);

            await Repository.UpdateAsync(director);

            return ObjectMapper.Map<Director, DirectorDto>(director);
        }
    }
    }