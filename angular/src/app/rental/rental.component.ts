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
  RentalService,
  RentalDto,
  CreateUpdateRentalDto,
} from '../proxy/rentals';

import { CustomerDto, CustomerService } from '../proxy/customers';
import { MovieDto, MovieService } from '../proxy/movies';

@Component({
  selector: 'app-rental',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  providers: [ListService],
  templateUrl: './rental.component.html',
  styleUrl: './rental.component.scss',
})
export class RentalComponent implements OnInit {

  private fb = inject(FormBuilder);
  private list = inject(ListService);
  private rentalService = inject(RentalService);
private customerService = inject(CustomerService);
private movieService = inject(MovieService);

  rentals: RentalDto[] = [];

  customers: CustomerDto[] = [];

  movies: MovieDto[] = [];

  form: FormGroup = this.fb.group({
    customerId: ['', Validators.required],
    movieId: ['', Validators.required],
    dueDate: ['', Validators.required],
  });

  isModalOpen = false;

  selectedRental: RentalDto | null = null;

  ngOnInit(): void {

    const rentalStreamCreator = (
      query: PagedAndSortedResultRequestDto
    ) => this.rentalService.getList(query);

    this.list
      .hookToQuery(rentalStreamCreator)
      .subscribe((response: PagedResultDto<RentalDto>) => {

        this.rentals = response.items ?? [];

      });

    this.loadCustomers();
    this.loadMovies();

  }

  loadCustomers() {


  this.customerService
    .getList({
      skipCount: 0,
      maxResultCount: 1000,
      sorting: ''
    })
    .subscribe(result => {

      this.customers = result.items ?? [];

    });

}

loadMovies() {

  this.movieService
    .getList({
      skipCount: 0,
      maxResultCount: 1000,
      sorting: ''
    })
    .subscribe(result => {

      this.movies = result.items ?? [];

    });

}
  openCreateModal() {

    this.selectedRental = null;

    this.form.reset();

    this.isModalOpen = true;

  }

  save() {

    if (this.form.invalid) {
      return;
    }

    const input: CreateUpdateRentalDto = {

      customerId: this.form.value.customerId,

      movieId: this.form.value.movieId,

      dueDate: this.form.value.dueDate,

    };

    this.rentalService
      .create(input)
      .subscribe(() => {

        this.list.get();

        this.isModalOpen = false;

      });

  }

  returnMovie(id?: string) {

    if (!id) {
      return;
    }

    this.rentalService
      .returnMovie(id)
      .subscribe(() => {

        this.list.get();

      });

  }

  deleteRental(id?: string) {

    if (!id) {
      return;
    }

    if (confirm('Delete rental?')) {

      this.rentalService
        .delete(id)
        .subscribe(() => {

          this.list.get();

        });

    }

  }

}