import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';

import {
  ListService,
  PagedAndSortedResultRequestDto,
  PagedResultDto,
} from '@abp/ng.core';

import {
  MovieService,
  MovieDto,
  CreateUpdateMovieDto,
} from '../proxy/movies';

import { DirectorDto } from '../proxy/directors';

@Component({
  selector: 'app-movie',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  providers: [ListService],
  templateUrl: './movie.component.html',
  styleUrl: './movie.component.scss',
})
export class MovieComponent implements OnInit {

  private fb = inject(FormBuilder);
  private list = inject(ListService);
  private movieService = inject(MovieService);

  movies: MovieDto[] = [];

  directors: DirectorDto[] = [];

  form: FormGroup = this.fb.group({
    title: ['', Validators.required],
    genre: [null],
    time: [''],
    price: [0],
    directorId: [''],
  });

  isModalOpen = false;

  selectedMovie: MovieDto | null = null;

  ngOnInit(): void {

    const movieStreamCreator = (
      query: PagedAndSortedResultRequestDto
    ) => this.movieService.getList(query);

    this.list
      .hookToQuery(movieStreamCreator)
      .subscribe((response: PagedResultDto<MovieDto>) => {
        this.movies = response.items ?? [];
      });

    this.loadDirectors();
  }

  loadDirectors() {
    this.movieService.getDirectors().subscribe(result => {
      this.directors = result;
    });
  }

  openCreateModal() {
    this.selectedMovie = null;
    this.form.reset();
    this.isModalOpen = true;
  }

  editMovie(movie: MovieDto) {

    this.selectedMovie = movie;

    this.form.patchValue({
      title: movie.title,
      genre: movie.genre,
      time: movie.time,
      price: movie.price,
      directorId: movie.directorId,
    });

    this.isModalOpen = true;
  }
    save() {

    if (this.form.invalid) {
      return;
    }

    const input: CreateUpdateMovieDto = {
      title: this.form.value.title,
      genre: this.form.value.genre,
      time: this.form.value.time,
      price: this.form.value.price,
      directorId: this.form.value.directorId,
    };

    if (this.selectedMovie) {

      this.movieService
        .update(this.selectedMovie.id!, input)
        .subscribe(() => {

          this.list.get();

          this.isModalOpen = false;

        });

    } else {

      this.movieService
        .create(input)
        .subscribe(() => {

          this.list.get();

          this.isModalOpen = false;

        });

    }

  }

  deleteMovie(id?: string) {

    if (!id) {
      return;
    }

    if (confirm('Delete movie?')) {

      this.movieService
        .delete(id)
        .subscribe(() => {

          this.list.get();

        });

    }

  }

}
