import type { CreateUpdateRentalDto, RentalDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable, inject } from '@angular/core';
import type { CustomerDto } from '../customers/models';
import type { MovieDto } from '../movies/models';

@Injectable({
  providedIn: 'root',
})
export class RentalService {
  private restService = inject(RestService);
  apiName = 'Default';
  

  create = (input: CreateUpdateRentalDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, RentalDto>({
      method: 'POST',
      url: '/api/app/rental',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/rental/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, RentalDto>({
      method: 'GET',
      url: `/api/app/rental/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getCustomers = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, CustomerDto[]>({
      method: 'GET',
      url: '/api/app/rental/customers',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<RentalDto>>({
      method: 'GET',
      url: '/api/app/rental',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getMovies = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, MovieDto[]>({
      method: 'GET',
      url: '/api/app/rental/movies',
    },
    { apiName: this.apiName,...config });
  

  returnMovie = (rentalId: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/app/rental/return-movie/${rentalId}`,
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateUpdateRentalDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, RentalDto>({
      method: 'PUT',
      url: `/api/app/rental/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });
}