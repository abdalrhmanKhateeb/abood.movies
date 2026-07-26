using Abood.Movies.Directors;
using Abood.Movies.Permissions;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Abood.Movies.Movies;

public class MovieAppService :
    CrudAppService<
        Movie,
        MovieDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateMovieDto>,
    IMovieAppService
{
    private readonly IRepository<Director, Guid> _directorRepository;
    private readonly IMovieRepository _movieRepository;
    
    public MovieAppService(
        IMovieRepository repository,
        IRepository<Movie, Guid> directorrepository,
        IRepository<Director, Guid> directorRepository)
        : base(repository)
    {
        _movieRepository = repository;
        _directorRepository = directorRepository;

        GetPolicyName = MoviesPermissions.Movies.Default;
        GetListPolicyName = MoviesPermissions.Movies.Default;
        CreatePolicyName = MoviesPermissions.Movies.Create;
        UpdatePolicyName = MoviesPermissions.Movies.Edit;
        DeletePolicyName = MoviesPermissions.Movies.Delete;
    }

    public async Task<List<DirectorDto>> GetDirectorsAsync()
    {
        var directors = await _directorRepository.GetListAsync();

        return ObjectMapper.Map<List<Director>, List<DirectorDto>>(directors);
    }
    
    
     
    
        
}