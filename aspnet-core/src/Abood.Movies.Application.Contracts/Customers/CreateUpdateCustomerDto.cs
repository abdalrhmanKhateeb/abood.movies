using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Abood.Movies.Customers
{
    public class CreateUpdateCustomerDto
    {
        [Required]
        [StringLength(128)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(256)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }
    }
}