using CoderCamps.Data.Repository;
using MovieAPI.Domain.Models;
using MovieAPI.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieAPI.Services {
    public class GenreService {
        private IRepository _repo;
        private MovieService _movieService;

        public GenreService(IRepository repo, MovieService movieService) {
            _repo = repo;
            _movieService = movieService;
        }

        public GenreDTO Map(Genre genre) {
            GenreDTO dto = new GenreDTO();

            dto.Id = genre.Id;
            dto.Name = genre.Name;
            dto.Movies = (from m in genre.Movies
                          select _movieService.Map(m)).ToList();

            return dto;
        }

        public Genre Map(GenreDTO dto) {
            Genre dbGenre = null;
            if ((dbGenre = FindInternal(dto.Id)) == null) {
                dbGenre = new Genre();
            }

            dbGenre.Name = dto.Name;
            dbGenre.Movies = (from m in _repo.Query<Movie>()
                              where dto.Movies.Any(movie => movie.Id == m.Id)
                              select m).ToList();

            return dbGenre;
        }

        public GenreDTO Find(int id) {
            return Map(FindInternal(id));
        }

        private Genre FindInternal(int id) {
            return (from m in _repo.Query<Genre>()
                    select m).FirstOrDefault();
        }

        public List<GenreDTO> List() {
            return (from m in _repo.Query<Genre>()
                    select Map(m)).ToList();
        }

        public void AddOrUpdate(GenreDTO dto) {
            Genre dbItem = Map(dto);
            if (dbItem.Id == 0) {
                _repo.Add(dbItem);
            }
            _repo.SaveChanges();
            dto.Id = dbItem.Id;
        }

        public void Delete(int id) {
            _repo.Delete<Genre>(id);
            _repo.SaveChanges();
        }
    }
}