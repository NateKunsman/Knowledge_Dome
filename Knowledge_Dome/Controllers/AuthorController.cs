using Dome.Models;
using Dome.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Knowledge_Dome.Controllers
{
    public class AuthorController : ApiController
    {
        public IHttpActionResult Get()
        {
            AuthorService authorService = CreateAuthorService();
            var authors = authorService.GetAuthors();
            return Ok(authors);
        }
        public IHttpActionResult Post(AuthorCreate author)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateAuthorService();
            if (!service.CreateAuthor(author))
                return InternalServerError();
            return Ok();
        }
        private AuthorService CreateAuthorService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new AuthorService(userId);
            return noteService;
        }
        public IHttpActionResult GetAuthorByName(string name)
        {
            AuthorService authorService = CreateAuthorService();
            var author = authorService.GetAuthorByName(name);
            return Ok(name);
        }
        public IHttpActionResult Put(AuthorEdit author)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateAuthorService();
            if (!service.UpdateAuthor (author))
                return InternalServerError();
            return Ok();
        }
    }
}
