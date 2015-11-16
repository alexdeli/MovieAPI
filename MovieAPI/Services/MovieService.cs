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
        private MapperService _mapper;

        public MovieService(IRepository repo, MapperService mapper) {
            _repo = repo;
            _mapper = mapper;
        }

        private IQueryable<Movie> Movies {
            get {
                return _repo.Query<Movie>()
                        .Include(m => m.Actors)
                        .Include(m => m.Producers)
                        .Include(m => m.Directors);
            }
        }

        public MovieDTO Find(int id) {
            return _mapper.Map(Movies.FirstOrDefault(m => m.Id == id));
        }

        public List<MovieDTO> List() {
            var movies = Movies.ToList();
            return (from m in Movies.ToList()
                    select _mapper.Map(m)).ToList();
        }

        public void AddOrUpdate(MovieDTO dto) {
            Movie dbItem = _mapper.Map(dto);
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