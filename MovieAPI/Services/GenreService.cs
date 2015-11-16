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
        private MapperService _mapper;

        public GenreService(IRepository repo, MapperService mapper) {
            _repo = repo;
            _mapper = mapper;
        }

        private IQueryable<Genre> Genres {
            get {
                return _repo.Query<Genre>()
                    .Include(g => g.Movies);
            }
        }
        public GenreDTO Find(int id) {
            return _mapper.Map(Genres.FirstOrDefault(g => g.Id == id));
        }

        public List<GenreDTO> List() {
            return (from g in Genres.ToList()
                    select _mapper.Map(g)).ToList();
        }

        public void AddOrUpdate(GenreDTO dto) {
            Genre dbItem = _mapper.Map(dto);
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