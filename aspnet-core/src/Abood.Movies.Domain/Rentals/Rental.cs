using Abood.Movies.Customers;
using Abood.Movies.Movies;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Abood.Movies.Rentals
{
    public class Rental : AuditedAggregateRoot<Guid>
    {
        public Guid CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public Guid MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        public DateTime RentalDate { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public bool IsReturned { get; set; }
         
        
    }

       
}

