using MovieAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieAPI.Services.Models
{
    public class GenreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MovieDTO> Movies { get; set; }
    }
}