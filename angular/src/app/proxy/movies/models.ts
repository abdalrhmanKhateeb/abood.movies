import type { MovieType } from './movie-type.enum';
import type { AuditedEntityDto } from '@abp/ng.core';

export interface CreateUpdateMovieDto {
  title: string;
  genre: MovieType;
  time?: string;
  price?: number;
  directorId: string;
}

export interface MovieDto extends AuditedEntityDto<string> {
  title?: string;
  genre?: MovieType;
  time?: string;
  price?: number;
  directorId?: string;
  directorName?: string | null;
}
