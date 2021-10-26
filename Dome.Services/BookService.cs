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

        public IEnumerable<BookLists> GetBooks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Books
                    .Select(e => new BookLists { BookId = e.BookId, Title = e.Title, AuthorName = e.Author.FirstName + e.Author.LastName, GenreName = e.Genre.GenreName });
                return query.ToArray();
            }
        }

        public BookDetails GetBookByTitle(string title)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Books.Single(e => e.Title == title);
                return
                    new BookDetails
                    {
                        BookId = entity.BookId,
                        Title = entity.Title,
                        BookLength = entity.BookLength,
                        AuthorName = entity.Author.FirstName + entity.Author.LastName,
                        GenreName = entity.Genre.GenreName,
                        DatePublished = entity.DatePublished,
                        ReadingLevel = entity.ReadingLevel,
                        ISBN = entity.ISBN
                    };
            }
        }

        public bool UpdateBook(BookEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Books.Single(e => e.BookId == model.BookId);
                entity.Title = model.Title;
                entity.ReadingLevel = model.ReadingLevel;
                entity.ISBN = model.ISBN;
                entity.BookLength = model.BookLength;
                entity.DatePublished = model.DatePublished;
                entity.ReadingLevel = model.ReadingLevel;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBook(int bookId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Books.Single(e => e.BookId == bookId);

                ctx.Books.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
