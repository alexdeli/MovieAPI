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

        private MapperService _mapper;
        
        public PersonService(IRepository repo, MapperService mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        private IQueryable<Person> Persons {
            get {
                return _repo.Query<Person>()
                    .Include(p => p.MoviesActedIn)
                    .Include(p => p.MoviesDirected)
                    .Include(p => p.MoviesProduced);
            }
        }

        //Find by Id: PersonDTO
        public PersonDTO Find(int id)
        {
            return _mapper.Map(Persons.FirstOrDefault(p => p.Id == id));
        }

        //List: PersonDT
        public List<PersonDTO> List()
        {
            return (from p in Persons.ToList()
                    select _mapper.Map(p)).ToList();
        }

        public void AddOrUpdate(PersonDTO dto) {
            Person dbItem = _mapper.Map(dto);
            if (dbItem.Id == 0) {
                _repo.Add(dbItem);
            }
            _repo.SaveChanges();
            dto.Id = dbItem.Id;
        }

        public void Delete(int id) {
            _repo.Delete<Person>(id);
            _repo.SaveChanges();
        }
    }
}