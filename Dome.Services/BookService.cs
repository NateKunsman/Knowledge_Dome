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
    public class BookService
    {
        private readonly Guid _userId;

        public BookService(Guid userId)
        {
            _userId = userId;
        }

        public bool Createbook(BookCreate model)
        {
            var entity = new Book()
            {
                Title = model.Title,
                BookLength = model.BookLength,
                DatePublished = model.DatePublished,
                ISBN = model.ISBN,
                AuthorId = model.AuthorId,
                GenreId = model.GenreId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Books.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
