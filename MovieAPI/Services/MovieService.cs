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

        private MovieDTO Map(Movie movie) {
            MovieDTO dto = new MovieDTO();
            dto.Id = movie.Id;
            dto.Title = movie.Title;
            dto.ReleaseDate = movie.ReleaseDate;

            return dto;
        }

        private Movie Map(MovieDTO dto) {
            Movie dbMovie = null;
            if ((dbMovie = FindInternal(dto.Id)) == null) {
                dbMovie = new Movie();
            }
            dbMovie.Title = dto.Title;
            dbMovie.ReleaseDate = dto.ReleaseDate;

            return dbMovie;
        }

        public MovieDTO Find(int id) {
            return Map(FindInternal(id));
        }

        private Movie FindInternal(int id) {
            return (from m in _repo.Query<Movie>()
                    select m).FirstOrDefault();
        }

        public List<MovieDTO> List() {
            return (from m in _repo.Query<Movie>()
                    select Map(m)).ToList();
        }

        public void AddOrUpdate(MovieDTO dto) {
            Movie dbItem = Map(dto);
            if (dbItem.Id == 0) {
                _repo.Add(dbItem);
            }
            _repo.SaveChanges();
        }

        public void Delete(int id) {
            _repo.Delete<Movie>(id);
            _repo.SaveChanges();
        }
    }
}