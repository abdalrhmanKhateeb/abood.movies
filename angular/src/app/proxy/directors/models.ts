import type { AuditedEntityDto } from '@abp/ng.core';

export interface CreateUpdateDirectorDto {
  name: string;
  nationality: string;
}

export interface DirectorDto extends AuditedEntityDto<string> {
  name?: string;
  nationality?: string;
}
