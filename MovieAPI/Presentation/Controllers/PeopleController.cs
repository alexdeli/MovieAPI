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
    public class PeopleController : ApiController
    {
        private PersonService _service;

        public PeopleController(PersonService service)
        {
            _service = service;
        }

        //GET: api/People
        public IEnumerable<PersonDTO> Get()
        {
            return _service.List();
        }

        //GET: api/People/*id*
        public PersonDTO Get(int id)
        {
            return _service.Find(id);
        }

        //POST: api/People
        public HttpResponseMessage Post(PersonDTO personDTO)
        {
            if(ModelState.IsValid)
            {
                _service.AddOrUpdate(personDTO);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            return Request.CreateResponse(HttpStatusCode.OK, personDTO);
        }

        //DELETE: Person
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
