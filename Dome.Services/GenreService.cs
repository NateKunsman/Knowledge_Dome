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
    public class GenreService
    {
        private readonly Guid _userId;

        public GenreService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateGenre(GenreCreate model)
        {
            var entity =
                new Genre()
                {
                    GenreName = model.GenreName 
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Genres.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //Get Genre
        public IEnumerable<GenreListItem> GetGenres()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Genres
                        .Select(
                            e =>
                                new GenreListItem
                                {
                                    GenreId = e.GenreId
                                }
                        );
                return query.ToArray();
            }
        }
        //Get Genre By Id
        public GenreDetail GetGenreById(int id)
        {
            using 
        }
    }
    
}
