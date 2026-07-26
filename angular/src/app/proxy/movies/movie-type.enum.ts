import { mapEnumToOptions } from '@abp/ng.core';

export enum MovieType {
  horror = 0,
  action = 1,
  romance = 2,
  adventure = 3,
}

export const movieTypeOptions = mapEnumToOptions(MovieType);
