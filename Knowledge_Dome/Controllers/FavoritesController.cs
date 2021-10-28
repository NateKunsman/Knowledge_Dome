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
    public class FavoritesController : ApiController
    {

        [HttpPost]
        public IHttpActionResult Post(FavoritesCreate book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateFavoriteService();

            if (!service.CreateFavorite(book))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Get(Guid userId)
        {
            FavoriteService favoriteService = CreateFavoriteService();
            var books = favoriteService.GetFavoriteByUserId(userId);
            return Ok(books);
        }

        private FavoriteService CreateFavoriteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var favoriteService = new FavoriteService(userId);
            return favoriteService;
        }
    }
}
