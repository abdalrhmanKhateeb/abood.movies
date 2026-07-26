using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Abood.Movies.Movies
{
    public class CreateUpdateMovieDto
    {
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public MovieType Genre { get; set; }

        public DateTime Time { get; set; }

        public float Price { get; set; }

        [Required]
        public Guid DirectorId { get; set; }


    }
}
