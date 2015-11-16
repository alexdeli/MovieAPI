using CoderCamps.Data.Repository;
using MovieAPI.Domain.Models;
using MovieAPI.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieAPI.Services
{
    public class PersonService
    {
        private IRepository _repo;

        private MovieService _movieService;

        public PersonService(IRepository repo, MovieService movieService)
        {
            _repo = repo;
            _movieService = movieService;
        }

        public PersonDTO Map(Person person)
        {
            PersonDTO dto = new PersonDTO();
            dto.Id = person.Id;
            dto.Name = person.Name;
            dto.Age = person.Age;
            dto.MoviesActedIn = (from m in person.MoviesActedIn?.AsQueryable()
                                 select _movieService.Map(m)).ToList();
        }

    }
}