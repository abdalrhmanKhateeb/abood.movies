using Abood.Movies.Directors;
using Abood.Movies.Permissions;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Abood.Movies.Movies;

public class MovieAppService :
    ApplicationService,
    IMovieAppService
{
    private readonly IMovieRepository _movieRepository;
    private readonly IRepository<Director, Guid> _directorRepository;


    public MovieAppService(
        IMovieRepository movieRepository,
        IRepository<Director, Guid> directorRepository)
    {
        _movieRepository = movieRepository;
        _directorRepository = directorRepository;
    }


    public async Task<MovieDto> GetAsync(Guid id)
    {
        var movie = await _movieRepository.GetWithDirectorAsync(id);

        if (movie == null)
        {
            throw new EntityNotFoundException(typeof(Movie), id);
        }

        return ObjectMapper.Map<Movie, MovieDto>(movie);
    }


    public async Task<PagedResultDto<MovieDto>> GetListAsync(
     PagedAndSortedResultRequestDto input)
    {
        var movies = await _movieRepository.GetListWithDirectorAsync();

        var items = ObjectMapper.Map<List<Movie>, List<MovieDto>>(movies);

        return new PagedResultDto<MovieDto>(
            items.Count,
            items
        );
    }


    public async Task<MovieDto> CreateAsync(CreateUpdateMovieDto input)
    {
        var movie = new Movie(
            GuidGenerator.Create(),
            input.Title,
            input.Genre,
            input.Time,
            input.Price,
            input.DirectorId
        );

        await _movieRepository.InsertAsync(movie);

        return ObjectMapper.Map<Movie, MovieDto>(movie);
    }


    public async Task<MovieDto> UpdateAsync(
        Guid id,
        CreateUpdateMovieDto input)
    {
        var movie = await _movieRepository.GetAsync(id);

        movie.SetTitle(input.Title);
        movie.SetPrice(input.Price);
        movie.SetGenre(input.Genre);
        movie.SetTime(input.Time);
        movie.SetDirector(input.DirectorId);

        await _movieRepository.UpdateAsync(movie);

        return ObjectMapper.Map<Movie, MovieDto>(movie);
    }


    public async Task DeleteAsync(Guid id)
    {
        await _movieRepository.DeleteAsync(id);
    }


    public async Task<List<DirectorDto>> GetDirectorsAsync()
    {
        var directors = await _directorRepository.GetListAsync();

        return ObjectMapper.Map<List<Director>, List<DirectorDto>>(directors);
    }

}