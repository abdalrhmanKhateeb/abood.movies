using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Abood.Movies.Rentals
{
    public class CreateUpdateRentalDto
    {
        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        public Guid MovieId { get; set; }

        [Required]
        public DateTime DueDate { get; set; }
    }

}