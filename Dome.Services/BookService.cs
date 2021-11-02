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

/*        public BookService(Guid userId)
        {
            _userId = userId;
        }*/
        //Creating a New Book
        public bool Createbook(BookCreate model)
        {
            var entity = new Book()
            {
                Title = model.Title,
                BookLength = model.BookLength,
                DatePublished = model.DatePublished,
                ISBN = model.ISBN,
                ReadingLevel = model.ReadingLevel,
                AuthorId = model.AuthorId
                //OwnerId = _userId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Books.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //Getting a listing of all books
        public IEnumerable<BookLists> GetBooks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Books
                    .Select(e => new BookLists 
                    { 
                        BookId = e.BookId, 
                        Title = e.Title, 
                        AuthorName = e.Author.FullName,
                    });
                return query.ToArray();

                
            }
        }
        //Getting the Book by Title
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
                        AuthorName = entity.Author.FullName,
                        DatePublished = entity.DatePublished,
                        ReadingLevel = entity.ReadingLevel,
                        ISBN = entity.ISBN,
                        Genres = entity.Genres.Select(n => new Genre
                        {
                            GenreId = n.Genre.GenreId,
                            GenreName = n.Genre.GenreName
                        }).ToList()
                        //OwnerId = _userId
                    };
            }
        }

        public IEnumerable<BookLists> GetBooksByAuthor(string authorName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Books
                    .Where(e => e.Author.FullName == authorName)
                    .Select(e => new BookLists { BookId = e.BookId, Title = e.Title, AuthorName = e.Author.FullName });
                return query.ToArray();
            }
        }

        public IEnumerable<BookLists> GetBooksByGenre(string genreName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .BookGenres
                    .Where(e => e.Genre.GenreName == genreName)
                    .Select(e => new BookLists { BookId = e.BookId, Title = e.Book.Title, AuthorName = e.Book.Author.FullName });
                return query.ToArray();
            }
        }

        //Updating Books
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
        //Deleting Books
        public bool DeleteBook(int bookId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Books.Single(e => e.BookId == bookId);

                ctx.Books.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        //Adding Genres

        public bool AddGenreToBook(int genreId, int bookId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = new BookGenre
                {
                    BookId = bookId,
                    GenreId = genreId
                };

                ctx.BookGenres.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
