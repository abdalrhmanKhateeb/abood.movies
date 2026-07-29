using Abood.Movies.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Abood.Movies.Directors;

[Authorize]
public class DirectorAppService :
    ApplicationService,
    IDirectorAppService
{
    private readonly IRepository<Director, Guid> _directorRepository;

    public DirectorAppService(
        IRepository<Director, Guid> directorRepository)
    {
        _directorRepository = directorRepository;
    }


    [Authorize(MoviesPermissions.Directors.Default)]
    public async Task<DirectorDto> GetAsync(Guid id)
    {
        var director = await _directorRepository.GetAsync(id);

        return ObjectMapper.Map<Director, DirectorDto>(director);
    }


    [Authorize(MoviesPermissions.Directors.Default)]
    public async Task<PagedResultDto<DirectorDto>> GetListAsync(
        PagedAndSortedResultRequestDto input)
    {
        var directors = await _directorRepository.GetListAsync();

        var items = ObjectMapper.Map<List<Director>, List<DirectorDto>>(directors);

        return new PagedResultDto<DirectorDto>(
            items.Count,
            items
        );
    }


    [Authorize(MoviesPermissions.Directors.Create)]
    public async Task<DirectorDto> CreateAsync(
        CreateUpdateDirectorDto input)
    {
        var director = new Director(
            GuidGenerator.Create(),
            input.Name,
            input.Nationality
        );

        await _directorRepository.InsertAsync(director);

        return ObjectMapper.Map<Director, DirectorDto>(director);
    }


    [Authorize(MoviesPermissions.Directors.Edit)]
    public async Task<DirectorDto> UpdateAsync(
        Guid id,
        CreateUpdateDirectorDto input)
    {
        var director = await _directorRepository.GetAsync(id);

        director.SetName(input.Name);
        director.SetNationality(input.Nationality);

        await _directorRepository.UpdateAsync(director);

        return ObjectMapper.Map<Director, DirectorDto>(director);
    }


    [Authorize(MoviesPermissions.Directors.Delete)]
    public async Task DeleteAsync(Guid id)
    {
        await _directorRepository.DeleteAsync(id);
    }
}