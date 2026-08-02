using Abood.Movies.Directors;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Abood.Movies.Movies
{
    public class Movie : AuditedAggregateRoot<Guid>
    {
        public virtual string Title { get; private set; }
        public virtual MovieType Genre { get; private set; }
        public virtual DateTime Time { get; private set; }
        public virtual decimal Price { get; private set; }
        public virtual Guid DirectorId { get; private set; }
        public virtual Director Director { get; private set; }



        protected Movie()
        {
        }

        public Movie(Guid id, string title, MovieType genre, DateTime time, decimal price, Guid directorId)
            : base(id)
        {
            SetTitle(title);
            SetPrice(price);
            Genre = genre;
            Time = time;
            DirectorId = directorId;
        }

        public Movie SetTitle(string title)
        {
            Title = Check.NotNullOrWhiteSpace(title, nameof(title), MoviesConsts.MaxTitleLength);
            return this;
        }

        public Movie SetPrice(decimal price)
        {
            if (price <= 0)
            {
                throw new BusinessException(MoviesDomainErrorCodes.InvalidPrice)
                    .WithData("Price", price);
            }

            Price = price;
            return this;
        }
        public Movie SetGenre(MovieType genre)
        {
            Genre = genre;
            return this;
        }


        public Movie SetTime(DateTime time)
        {
            Time = time;
            return this;
        }


        public Movie SetDirector(Guid directorId)
        {
            DirectorId = directorId;
            return this;
        }
    }
}
