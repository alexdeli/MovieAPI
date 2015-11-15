using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieAPI.Services.Models {
    public class MovieDTO {

        public int Id { get; set; }
        public string Title { get; set; }
        //public List<Person> Directors { get; set; }
        //public List<Person> Producers { get; set; }
        //public List<Person> Actors { get; set; }
        public DateTime ReleaseDate { get; set; }
        //public List<Genre> Genres { get; set; }
    }
}