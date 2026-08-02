using Abood.Movies.Customers;
using Abood.Movies.Movies;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Abood.Movies.Rentals
{
    public class Rental : AuditedAggregateRoot<Guid>
    {
        public Guid CustomerId { get; private set; }

        public virtual Customer Customer { get; private set; }

        public Guid MovieId { get; private set; }

        public virtual Movie Movie { get; private set; }

        public DateTime RentalDate { get; private set; }

        public DateTime DueDate { get; private set; }

        public DateTime? ReturnDate { get; private set; }

        public bool IsReturned { get; private set; }



        protected Rental()
        {
        }


        public Rental(
            Guid id,
            Guid customerId,
            Guid movieId,
            DateTime rentalDate,
            DateTime dueDate)
            : base(id)
        {
            CustomerId = customerId;
            MovieId = movieId;
            RentalDate = rentalDate;

            SetDueDate(dueDate);

            IsReturned = false;
        }


        public Rental SetDueDate(DateTime dueDate)
        {
            if (dueDate < DateTime.Now)
            {
                throw new BusinessException(
                    MoviesDomainErrorCodes.DueDateCannotBePast);
            }

            DueDate = dueDate;

            return this;
        }


        public Rental ReturnMovie()
        {
            if (IsReturned)
            {
                throw new BusinessException(
                    MoviesDomainErrorCodes.RentalAlreadyReturned);
            }

            IsReturned = true;
            ReturnDate = DateTime.Now;

            return this;
        }
    }
}