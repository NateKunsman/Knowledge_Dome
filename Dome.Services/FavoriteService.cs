using Dome.Data;
using Dome.Models;
using Knowledge_Dome.Dome.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dome.Services
{
    public class FavoriteService
    {
        private readonly Guid _userId;

        public FavoriteService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateFavorite(FavoritesCreate model)
        {
            var entity = new Favorite()
            {
                BookId = model.BookId,
                UserId = _userId
            };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Favorites.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FavoriteLists> GetFavoriteByUserId(Guid userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Favorites
                    .Where(e => e.UserId == userId)
                    .Select(e => new FavoriteLists { BookTitle = e.Book.Title/*, AuthorName = e.Book.Author.FullName, Genres = e.Book.Genres.Select(n => new Genre { GenreName = n.Genre.GenreName }).ToList()*/ });
                return query.ToArray();
            }
        }

        public bool UpdateFavorites(FavoritesEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Favorites.Single(e => e.FavoriteId == model.FavoritesId);
                entity.BookId = model.BookId;
                entity.UserId = model.UserId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteFavorite(int favoriteId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Favorites.Single(e => e.FavoriteId == favoriteId);

                ctx.Favorites.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
