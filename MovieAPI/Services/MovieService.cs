using CoderCamps.Data.Repository;
using MovieAPI.Domain.Models;
using MovieAPI.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieAPI.Services {
    public class MovieService {

        private IRepository _repo;

        public MovieService(IRepository repo) {
            _repo = repo;
        }

        public MovieDTO Map(Movie movie) {
            MovieDTO dto = new MovieDTO();
            dto.Id = movie.Id;
            dto.Title = movie.Title;
            dto.ReleaseDate = movie.ReleaseDate;

            return dto;
        }

        public Movie Map(MovieDTO dto) {
            Movie dbMovie = null;
            if ((dbMovie = FindInternal(dto.Id)) == null) {
                dbMovie = new Movie();
            }

        }

        private Movie FindInternal(int id) {
            return _repo.Find<Movie>(id);
        }
    }
}