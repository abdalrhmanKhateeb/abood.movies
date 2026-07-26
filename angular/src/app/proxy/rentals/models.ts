import type { AuditedEntityDto } from '@abp/ng.core';

export interface CreateUpdateRentalDto {
  customerId: string;
  movieId: string;
  dueDate: string;
}

export interface RentalDto extends AuditedEntityDto<string> {
  customerId?: string;
  customerName?: string;
  movieId?: string;
  movieTitle?: string;
  rentalDate?: string;
  dueDate?: string;
  returnDate?: string | null;
  isReturned?: boolean;
}
