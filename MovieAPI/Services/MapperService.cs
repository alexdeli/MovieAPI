using CoderCamps.Data.Repository;
using MovieAPI.Domain.Models;
using MovieAPI.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieAPI.Services {
    public class MapperService {

        private IRepository _repo;

        public MapperService(IRepository repo) {
            _repo = repo;
        }

        public MovieDTO Map(Movie movie, bool recursive = true) {
            MovieDTO dto = new MovieDTO();
            dto.Id = movie.Id;
            dto.Title = movie.Title;
            dto.ReleaseDate = movie.ReleaseDate;

            if (recursive && movie.Actors != null) {
                dto.Actors = (from a in movie.Actors
                              select Map(a, false)).ToList();
            }
            if (recursive && movie.Directors != null) {
                dto.Directors = (from a in movie.Directors
                                 select Map(a, false)).ToList();
            }
            if (recursive && movie.Producers != null) {
                dto.Producers = (from a in movie.Producers
                                 select Map(a, false)).ToList();
            }
            if (recursive && movie.Genres != null) {
                dto.Genres = (from g in movie.Genres
                              select Map(g)).ToList();
            }
            return dto;
        }

        public Movie Map(MovieDTO dto, bool recursive = true) {
            Movie dbMovie = null;
            if ((dbMovie = _repo.Find<Movie>(dto.Id)) == null) {
                dbMovie = new Movie();
            }
            dbMovie.Title = dto.Title;
            dbMovie.ReleaseDate = dto.ReleaseDate;
            if (dto.Actors != null) {
                dbMovie.Actors = (from a in _repo.Query<Person>()
                                  where dto.Actors.Any(actor => actor.Id == a.Id)
                                  select a).ToList();
            }
            if (dto.Directors != null) {
                dbMovie.Directors = (from a in _repo.Query<Person>()
                                     where dto.Directors.Any(actor => actor.Id == a.Id)
                                     select a).ToList();
            }
            if (dto.Producers != null) {
                dbMovie.Producers = (from a in _repo.Query<Person>()
                                     where dto.Producers.Any(actor => actor.Id == a.Id)
                                     select a).ToList();
            }
            if (dto.Genres != null) {
                dbMovie.Genres = (from g in _repo.Query<Genre>()
                                  where dto.Genres.Any(genre => genre.Id == g.Id)
                                  select g).ToList();
            }

            return dbMovie;
        }

        //Map: Person DBO to a Person DTO
        public PersonDTO Map(Person person, bool recursive = true) {
            PersonDTO dto = new PersonDTO();
            dto.Id = person.Id;
            dto.Name = person.Name;
            dto.Age = person.Age;
            if (recursive && person.MoviesActedIn != null) {
                dto.MoviesActedIn = (from m in person.MoviesActedIn
                                     select Map(m, false)).ToList();
            }
            if (recursive && person.MoviesDirected != null) {
                dto.MoviesDirected = (from m in person.MoviesDirected
                                      select Map(m, false)).ToList();
            }
            if (recursive && person.MoviesProduced != null) {
                dto.MoviesProduced = (from m in person.MoviesProduced
                                      select Map(m, false)).ToList();
            }
            return dto;
        }

        //Map: Person DTO to Person DBO
        public Person Map(PersonDTO dto) {
            Person dbPerson = null;
            if ((dbPerson = _repo.Find<Person>(dto.Id)) == null) {
                dbPerson = new Person();
            }
            dbPerson.Name = dto.Name;
            dbPerson.Age = dto.Age;

            if (dto.MoviesActedIn != null) {
                dbPerson.MoviesActedIn = (from m in _repo.Query<Movie>()
                                          where dto.MoviesActedIn.Any(movie => movie.Id == m.Id)
                                          select m).ToList();
            }
            if (dto.MoviesDirected != null) {
                dbPerson.MoviesDirected = (from m in _repo.Query<Movie>()
                                           where dto.MoviesDirected.Any(movie => movie.Id == m.Id)
                                           select m).ToList();
            }
            if (dto.MoviesProduced != null) {
                dbPerson.MoviesProduced = (from m in _repo.Query<Movie>()
                                           where dto.MoviesProduced.Any(movie => movie.Id == m.Id)
                                           select m).ToList();
            }

            return dbPerson;
        }

        public GenreDTO Map(Genre genre, bool recursive = true) {
            GenreDTO dto = new GenreDTO();

            dto.Id = genre.Id;
            dto.Name = genre.Name;
            if (recursive && genre.Movies != null) {
                dto.Movies = (from m in genre.Movies
                              select Map(m, false)).ToList();
            }

            return dto;
        }

        public Genre Map(GenreDTO dto) {
            Genre dbGenre = null;
            if ((dbGenre = _repo.Find<Genre>(dto.Id)) == null) {
                dbGenre = new Genre();
            }

            dbGenre.Name = dto.Name;
            if (dto.Movies != null) {
                dbGenre.Movies = (from m in _repo.Query<Movie>()
                                  where dto.Movies.Any(movie => movie.Id == m.Id)
                                  select m).ToList();
            }

            return dbGenre;
        }
    }
}