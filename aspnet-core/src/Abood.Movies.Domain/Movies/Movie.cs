using Abood.Movies.Directors;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Abood.Movies.Movies
{
    public class Movie : AuditedAggregateRoot<Guid>
    {
        public string Title { get; set; }

        public  MovieType Genre {  get; set; }

        public DateTime Time { get; set; }

        public float Price { get; set; } 

        public Guid DirectorId { get; set; }

        public virtual Director Director { get; set; }


    }
}
