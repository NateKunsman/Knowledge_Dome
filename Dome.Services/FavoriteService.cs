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
                    .Select(e => new FavoriteLists { BookTitle = e.Book.Title, AuthorName = e.Book.Author.FullName, GenreName = e.Book.Genre.GenreName });
                return query.ToArray();
            }
        }
    }
}
