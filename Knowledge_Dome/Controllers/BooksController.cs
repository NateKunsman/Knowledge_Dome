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
    public class BooksController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            BookService bookService = CreateBookService();
            var books = bookService.GetBooks();
            return Ok(books);
        }
        [HttpGet]
        public IHttpActionResult Get(string title)
        {
            BookService bookService = CreateBookService();
            var book = bookService.GetBookByTitle(title);
            return Ok(book);
        }
        [HttpGet]
        public IHttpActionResult GetByAuthor(string authorFullName)
        {
            BookService bookService = CreateBookService();
            var books = bookService.GetBooksByAuthor(authorFullName);
            return Ok(books);
        }
        [HttpGet]
        public IHttpActionResult GetByGenre(string genreName)
        {
            BookService bookService = CreateBookService();
            var books = bookService.GetBooksByGenre(genreName);
            return Ok(books);
        }
        [HttpPost]
        public IHttpActionResult Post(BookCreate book)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateBookService();

            if (!service.Createbook(book))
                return InternalServerError();
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Put(BookEdit book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateBookService();
            if (!service.UpdateBook(book))
                return InternalServerError();
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateBookService();

            if (!service.DeleteBook(id))
                return InternalServerError();

            return Ok();
        }

        private BookService CreateBookService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var bookService = new BookService(userId);
            return bookService;
        }
    }
}
