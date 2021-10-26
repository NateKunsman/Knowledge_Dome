using Dome.Services;
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
    }
}
