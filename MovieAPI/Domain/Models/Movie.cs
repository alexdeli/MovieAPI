using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieAPI.Domain.Models {
    public class Movie {

        public int Id { get; set; }
        public string Title { get; set; }

        [InverseProperty("MoviesDirected")]
        public List<Person> Directors { get; set; }

        [InverseProperty("MoviesProduced")]
        public List<Person> Producers { get; set; }

        [InverseProperty("MoviesActedIn")]
        public List<Person> Actors { get; set; }

        public DateTime ReleaseDate { get; set; }

        public List<Genre> Genres { get; set; }
    }
}