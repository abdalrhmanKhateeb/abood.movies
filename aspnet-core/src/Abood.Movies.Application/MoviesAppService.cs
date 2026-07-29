using Abood.Movies.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;

namespace Abood.Movies.Movies;

public class MovieAppService :
    ApplicationService,
    IMovieAppService
{
    private readonly IMovieRepository _movieRepository;

    public MovieAppService(
        IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    [Authorize(MoviesPermissions.Movies.Default)]
    public async Task<MovieDto> GetAsync(Guid id)
    {
        var movie = await _movieRepository.GetWithDirectorAsync(id);

        if (movie == null)
        {
            throw new EntityNotFoundException(typeof(Movie), id);
        }

        return ObjectMapper.Map<Movie, MovieDto>(movie);
    }

    [Authorize(MoviesPermissions.Movies.Default)]
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

    [Authorize(MoviesPermissions.Movies.Create)]
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

        var createdMovie = await _movieRepository.GetWithDirectorAsync(movie.Id);

        return ObjectMapper.Map<Movie, MovieDto>(createdMovie!);
    }

    [Authorize(MoviesPermissions.Movies.Edit)]
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

        var updatedMovie = await _movieRepository.GetWithDirectorAsync(id);

        return ObjectMapper.Map<Movie, MovieDto>(updatedMovie!);
    }

    [Authorize(MoviesPermissions.Movies.Delete)]
    public async Task DeleteAsync(Guid id)
    {
        await _movieRepository.DeleteAsync(id);
    }
}