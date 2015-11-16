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
        private PersonService _personService;
        private GenreService _genreService;

        public MovieService(IRepository repo, PersonService personService, GenreService genreService) {
            _repo = repo;
            _personService = personService;
            _genreService = genreService;
        }

        public MovieDTO Map(Movie movie) {
            MovieDTO dto = new MovieDTO();
            dto.Id = movie.Id;
            dto.Title = movie.Title;
            dto.ReleaseDate = movie.ReleaseDate;

            dto.Actors = (from a in movie.Actors
                          select _personService.Map(a)).ToList();
            dto.Directors = (from a in movie.Directors
                             select _personService.Map(a)).ToList();
            dto.Producers = (from a in movie.Producers
                             select _personService.Map(a)).ToList();
            dto.Genres = (from g in movie.Genres
                          select _genreService.Map(g)).ToList();
            return dto;
        }

        public Movie Map(MovieDTO dto) {
            Movie dbMovie = null;
            if ((dbMovie = FindInternal(dto.Id)) == null) {
                dbMovie = new Movie();
            }
            dbMovie.Title = dto.Title;
            dbMovie.ReleaseDate = dto.ReleaseDate;
            dbMovie.Actors = (from a in _repo.Query<Person>()
                              where dto.Actors.Any(actor => actor.Id == a.Id)
                              select a).ToList();
            dbMovie.Directors = (from a in _repo.Query<Person>()
                                 where dto.Directors.Any(actor => actor.Id == a.Id)
                                 select a).ToList();
            dbMovie.Producers = (from a in _repo.Query<Person>()
                                 where dto.Producers.Any(actor => actor.Id == a.Id)
                                 select a).ToList();
            dbMovie.Genres = (from g in _repo.Query<Genre>()
                              where dto.Genres.Any(genre => genre.Id == g.Id)
                              select g).ToList();

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
            dto.Id = dbItem.Id;
        }

        public void Delete(int id) {
            _repo.Delete<Movie>(id);
            _repo.SaveChanges();
        }
    }
}