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

        //Map: Person DBO to a Person DTO
        public PersonDTO Map(Person person)
        {
            PersonDTO dto = new PersonDTO();
            dto.Id = person.Id;
            dto.Name = person.Name;
            dto.Age = person.Age;
            dto.MoviesActedIn = (from m in person.MoviesActedIn?.AsQueryable()
                                 select _movieService.Map(m)).ToList();
            dto.MoviesDirected = (from m in person.MoviesDirected?.AsQueryable()
                                  select _movieService.Map(m)).ToList();
            dto.MoviesProduced = (from m in person.MoviesProduced?.AsQueryable()
                                  select _movieService.Map(m)).ToList();


            return dto;
        }

        //Map: Person DTO to Person DBO
        public Person Map(PersonDTO dto)
        {
            Person dbPerson = null;
            if ((dbPerson = FindInternal(dto.Id)) == null)
            {
                dbPerson = new Person();
            }
            dbPerson.Name = dto.Name;
            dbPerson.Age = dto.Age;

            dbPerson.MoviesActedIn = (from m in dto.MoviesActedIn?.AsQueryable()
                                      select _movieService.Map(m)).ToList();
            dbPerson.MoviesDirected = (from m in dto.MoviesDirected?.AsQueryable()
                                       select _movieService.Map(m)).ToList();
            dbPerson.MoviesProduced = (from m in dto.MoviesProduced?.AsQueryable()
                                       select _movieService.Map(m)).ToList();

            return dbPerson;
        }

        //Find by Id: PersonDTO
        public PersonDTO Find(int id)
        {
            return Map(FindInternal(id));
        }

        //List: PersonDT
        public List<PersonDTO> List()
        {
            return (from p in _repo.Query<Person>()
                    select Map(p)).ToList();
        }
        //Find Internal: Person
        public Person FindInternal(int id)
        {
            return (from p in _repo.Query<Person>()
                    select p).FirstOrDefault();
        }



    }
}