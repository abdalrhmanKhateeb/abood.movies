using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Abood.Movies.Customers
{
    public class CustomerDto : AuditedEntityDto<Guid>
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
    }
