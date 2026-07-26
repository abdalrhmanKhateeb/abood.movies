using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Abood.Movies.Movies
{
    public class MovieDto : AuditedEntityDto<Guid>
    {
        public string Title { get; set; }

        public MovieType Genre { get; set; }

        public DateTime Time { get; set; }

        public float Price { get; set; }

        public Guid DirectorId { get; set; }

        public string? DirectorName { get; set; }

    }
}
