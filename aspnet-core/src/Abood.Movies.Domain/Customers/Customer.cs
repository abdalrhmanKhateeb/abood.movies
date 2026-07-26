using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Abood.Movies.Customers
{
    public class Customer : AuditedAggregateRoot<Guid>
    {
        public string FullName{ get; set; }

        public string Email {  get; set; }

        public string PhoneNumber { get; set; }
    }
}
