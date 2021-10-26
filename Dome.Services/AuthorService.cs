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
    public class AuthorService
    {
        private readonly Guid _userId;
        public AuthorService(Guid userId)
        {
            _userId = userId;
        }
        //CRUD
        //Create Author
        public bool CreateAuthor(AuthorCreate model)
        {
            var entity =
                new Author()
                {
                    AuthorId = model.AuthorId,
                    FullName = model.FullName
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Authors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //Get Author
        public IEnumerable<AuthorList> GetAuthors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var quary = ctx.Authors
                    .Select(e => new AuthorList { FullName = e.FullName });

                return quary.ToArray();
            }
        }
        //Get Author by ID
        public AuthorDetail GetAuthorById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Authors.Single(e => e.AuthorId == id);
            return
                new AuthorDetail
                {
                    AuthorId = entity.AuthorId,
                    FullName = entity.FullName,
                };
            }
        }
        //Get Author by name
        public AuthorDetail GetAuthorByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Authors.Single(e => e.FullName == name);
                return
                    new AuthorDetail
                    {
                        AuthorId = entity.AuthorId,
                        FullName = entity.FullName
                    };
           }
        }
        //Edit Author
        public bool UpdateAuthor(AuthorEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Authors
                        .Single(e => e.AuthorId == model.AuthorId);
                entity.FullName = model.FullName;
                return ctx.SaveChanges() == 1;
            }
        }
        //Delete Author
        public bool DeleteAuthor (int authorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Authors;
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
