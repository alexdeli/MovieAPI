using MovieAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieAPI.Services.Models {
    public class MovieDTO {

        public int Id { get; set; }
        public string Title { get; set; }
        public List<PersonDTO> Directors { get; set; }
        public List<PersonDTO> Producers { get; set; }
        public List<PersonDTO> Actors { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<GenreDTO> Genres { get; set; }
    }
}