import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { LocalizationPipe } from '@abp/ng.core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
  
} from '@angular/forms';

import {
  LocalizationService,
  ListService,
  PagedAndSortedResultRequestDto,
  PagedResultDto,
} from '@abp/ng.core';

import {
  CustomerService,
  CustomerDto,
  CreateUpdateCustomerDto,
} from '../proxy/customers';

@Component({
  selector: 'app-customer',
  standalone: true,
  imports: [
  CommonModule,
  ReactiveFormsModule,
  LocalizationPipe,
],
  providers: [ListService],
  templateUrl: './customer.component.html',
  styleUrl: './customer.component.scss',
})
export class CustomerComponent implements OnInit {

  private fb = inject(FormBuilder);
  private list = inject(ListService);
  private customerService = inject(CustomerService);
  private localizationService = inject(LocalizationService);

  customers: CustomerDto[] = [];

  form: FormGroup = this.fb.group({
    fullName: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    phoneNumber: ['', Validators.required],
  });

  isModalOpen = false;

  selectedCustomer: CustomerDto | null = null;

  ngOnInit(): void {

    const customerStreamCreator = (
      query: PagedAndSortedResultRequestDto
    ) => this.customerService.getList(query);

    this.list
      .hookToQuery(customerStreamCreator)
      .subscribe((response: PagedResultDto<CustomerDto>) => {

        this.customers = response.items ?? [];

      });

  }

  openCreateModal() {

    this.selectedCustomer = null;

    this.form.reset();

    this.isModalOpen = true;

  }

  editCustomer(customer: CustomerDto) {

    this.selectedCustomer = customer;

    this.form.patchValue({
      fullName: customer.fullName,
      email: customer.email,
      phoneNumber: customer.phoneNumber,
    });

    this.isModalOpen = true;

  }

  save() {

    if (this.form.invalid) {
      return;
    }

    const input: CreateUpdateCustomerDto = {

      fullName: this.form.value.fullName,

      email: this.form.value.email,

      phoneNumber: this.form.value.phoneNumber,

    };

    if (this.selectedCustomer) {

      this.customerService
        .update(this.selectedCustomer.id!, input)
        .subscribe(() => {

          this.list.get();

          this.isModalOpen = false;

        });

    } else {

      this.customerService
        .create(input)
        .subscribe(() => {

          this.list.get();

          this.isModalOpen = false;

        });

    }

  }

  deleteCustomer(id?: string) {

    if (!id) {
      return;
    }

    if (
  confirm(
    this.localizationService.instant('DeleteCustomerConfirmation')
  )
) { 

      this.customerService
        .delete(id)
        .subscribe(() => {

          this.list.get();

        });

    }

  }

}