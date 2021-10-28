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

/*        public GenreService(Guid userId)
        {
            _userId = userId;
        }*/
        //CRUD
        //Create
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
        //Get Genre (Read)
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
                                    GenreId = e.GenreId,
                                    GenreName = e.GenreName
                                }
                        );
                return query.ToArray();
            }
        }
        //Get Genre By Id
        public GenreDetail GetGenreById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Genres.Single(e => e.GenreId == id);
                return
                    new GenreDetail
                    {
                        GenreId = entity.GenreId,
                        GenreName = entity.GenreName
                    };
            }
        }

        //Edit Genre (Update)
        public bool UpdateGenre(GenreEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Genres.Single(e => e.GenreId == model.GenreId);

                entity.GenreName = model.GenreName;
                return ctx.SaveChanges() == 1;
            }
        }
        //Delete Genre (Delete)
        public bool DeleteGenre(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Genres.Single(e => e.GenreId == id);
                ctx.Genres.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
    
}
