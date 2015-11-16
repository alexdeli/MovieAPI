using MovieAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieAPI.Services.Models
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public int Age { get; set; }
        public List<MovieDTO> MoviesActedIn { get; set; }
        public List<MovieDTO> MoviesDirected { get; set; }
        public List<MovieDTO> MoviesProduced { get; set; }
    }
}