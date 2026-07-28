using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Abood.Movies.Customers
{
    public class Customer : AuditedAggregateRoot<Guid>
    {
        public   string FullName{ get;  private set; }

        public string Email {  get;  private set; }

        public string PhoneNumber { get; private  set; }
        protected Customer()
        {
        }


        public Customer(
            Guid id,
            string fullName,
            string email,
            string phoneNumber)
            : base(id)
        {
            SetFullName(fullName);
            SetEmail(email);
            SetPhoneNumber(phoneNumber);
        }


        public Customer SetFullName(string fullName)
        {
            FullName = Check.NotNullOrWhiteSpace(
                fullName,
                nameof(fullName),
                100);

            return this;
        }


        public Customer SetEmail(string email)
        {
            Email = Check.NotNullOrWhiteSpace(
                email,
                nameof(email),
                256);

            return this;
        }


        public Customer SetPhoneNumber(string phoneNumber)
        {
            PhoneNumber = Check.NotNullOrWhiteSpace(
                phoneNumber,
                nameof(phoneNumber),
                20);

            return this;
        }
    }
}

