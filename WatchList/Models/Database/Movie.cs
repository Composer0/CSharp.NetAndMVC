using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using WatchList.Enums;

namespace WatchList.Models.Database
{
    public class Movie
    {
        public int Id { get; set; }
        public int MovieId { get; set; } //as TMDB see it.
        public string Title { get; set; }
        public string Overview { get; set; }
        public string TagLine { get; set; }
        public int RunTime { get; set; }

        [DataType(DataType.Date)] // ensures we only get the date, not the time. Time will be stored as zero.
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public MovieRating Rating { get; set; } //MovieRating type is relying on a enum.
        public float VoteAverage { get; set; } //1 - 10 property.

        [Display(Name = "Poster")]
        public byte[] Poster { get; set; } //byte being used because we are rendering an image. Must be stored as digital data.
        public string PosterType { get; set; }

        [Display(Name = "Backdrop")]
        public byte[] Backdrop { get; set; }
        public string BackdropType { get; set; }

        public string TrailerUrl { get; set; }

        [NotMapped] // Prevent PostgreSQL errors.
        [Display(Name = "Poster Image")]
        public IFormFile PosterFile { get; set; }

        [NotMapped] // Prevent PostgreSQL errors.
        [Display(Name = "Backdrop Image")]
        public IFormFile BackdropFile { get; set; }

        public ICollection<MovieCollection> MovieCollections { get; set; } = new HashSet<MovieCollection>(); //Navigation property to combine and initialize this with the Collection model into the Movie Collection model.
        public ICollection<MovieCast> Cast { get; set; } = new HashSet<MovieCast>(); //Navigation property that indicates that Movie is a parent model that will provide information to the Movie Cast model.
        public ICollection <MovieCrew> Crew { get; set; } = new HashSet<MovieCrew>();//Navigation property that indicates that Movie is a parent model that will provide information to the Movie Crew model.
    }
}
