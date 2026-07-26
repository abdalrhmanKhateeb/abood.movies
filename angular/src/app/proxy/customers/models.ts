import type { AuditedEntityDto } from '@abp/ng.core';

export interface CreateUpdateCustomerDto {
  fullName: string;
  email: string;
  phoneNumber: string;
}

export interface CustomerDto extends AuditedEntityDto<string> {
  fullName?: string;
  email?: string;
  phoneNumber?: string;
}
