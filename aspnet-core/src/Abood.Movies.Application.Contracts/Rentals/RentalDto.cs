using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Abood.Movies.Rentals
{
    public class RentalDto : AuditedEntityDto<Guid>
    {
        public Guid CustomerId { get; set; }

        public string CustomerName { get; set; }

        public Guid MovieId { get; set; }

        public string MovieTitle { get; set; }

        public DateTime RentalDate { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public bool IsReturned { get; set; }
       
    }
}
