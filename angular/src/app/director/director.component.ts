import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { PagedAndSortedResultRequestDto } from '@abp/ng.core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';

import { ListService, PagedResultDto } from '@abp/ng.core';

import {
  DirectorDto,
  DirectorService,
  CreateUpdateDirectorDto,
} from '../proxy/directors';

@Component({
  selector: 'app-director',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  providers: [ListService],
  templateUrl: './director.component.html',
  styleUrl: './director.component.scss',
})
export class DirectorComponent implements OnInit {
  private fb = inject(FormBuilder);
  private list = inject(ListService);
  private directorService = inject(DirectorService);

  directors: DirectorDto[] = [];

  form: FormGroup = this.fb.group({
    name: ['', Validators.required],
    nationality: ['', Validators.required],
  });

  isModalOpen = false;

  selectedDirector: DirectorDto | null = null;

  ngOnInit(): void {
   const directorStreamCreator = (query: PagedAndSortedResultRequestDto) =>
  this.directorService.getList(query);

    this.list.hookToQuery(directorStreamCreator).subscribe((response: PagedResultDto<DirectorDto>) => {
this.directors = response.items ?? [];    });
  }

  openCreateModal() {
    this.selectedDirector = null;
    this.form.reset();
    this.isModalOpen = true;
  }

  editDirector(director: DirectorDto) {
    this.selectedDirector = director;

    this.form.patchValue({
      name: director.name,
      nationality: director.nationality,
    });

    this.isModalOpen = true;
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    const input: CreateUpdateDirectorDto = {
      name: this.form.value.name,
      nationality: this.form.value.nationality,
    };

    if (this.selectedDirector) {
      this.directorService
        .update(this.selectedDirector.id!, input)
        .subscribe(() => {
          this.list.get();
          this.isModalOpen = false;
        });
    } else {
      this.directorService.create(input).subscribe(() => {
        this.list.get();
        this.isModalOpen = false;
      });
    }
  }

  deleteDirector(id?: string) {
    if (!id) return;

    if (confirm('Delete this director?')) {
      this.directorService.delete(id).subscribe(() => {
        this.list.get();
      });
    }
  }

}