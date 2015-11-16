using MovieAPI.Services;
using MovieAPI.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieAPI.Presentation.Controllers
{
    public class MoviesController : ApiController
    {
        private MovieService _service;

        public MoviesController(MovieService service) {
            _service = service;
        }

        // GET: api/Movies
        public IEnumerable<MovieDTO> Get() {
            return _service.List();
        }

        // GET: api/Movies/5
        public MovieDTO Get(int id) {
            return _service.Find(id);
        }

        // POST: api/Movies
        public HttpResponseMessage Post(MovieDTO movieDto) {
            if (ModelState.IsValid) {
                _service.AddOrUpdate(movieDto);
            }
            else {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            return Request.CreateResponse(HttpStatusCode.OK, movieDto);
        }

        // DELETE: api/Movies/5
        public void Delete(int id) {
            _service.Delete(id);
        }
    }
}
