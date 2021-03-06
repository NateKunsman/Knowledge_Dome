using Dome.Data;
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
    [Authorize]
    public class GenreController : ApiController
    {
        private GenreService CreateGenreService()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            var genreService = new GenreService();
            return genreService;
        }
        // Get All Genre
        public IHttpActionResult Get()
        {
            GenreService genreService = CreateGenreService();
            var genres = genreService.GetGenres();
            return Ok(genres);
        }

        public IHttpActionResult Post(GenreCreate genre)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGenreService();

            if (!service.CreateGenre(genre))
                return InternalServerError();

            return Ok();
        }
        // Get By Genre Id
        public IHttpActionResult Get(int id)
        {
            GenreService genreService = CreateGenreService();
            var genre = genreService.GetGenreById(id);
            return Ok(genre);
        }

        //Edit Genre
        public IHttpActionResult Put(GenreEdit genre)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGenreService();

            if (!service.UpdateGenre(genre))
                return InternalServerError();

            return Ok();
        }
        //Delete Genre
        public IHttpActionResult Delete(int id)
        {
            var service = CreateGenreService();

            if (!service.DeleteGenre(id))
                return InternalServerError();
            return Ok();
        }
    }
}
