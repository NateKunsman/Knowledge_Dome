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
    public class QuoteService
    {
        private readonly Guid _userId;
        public QuoteService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateQuote(QuoteCreate model)
        {
            var entity = new Quote()
            {
                BookId = model.BookId,
                UserId = _userId,
                QuoteText = model.QuoteText
            };
            using(var ctx = new ApplicationDbContext())
            {
                ctx.Quotes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<QuoteList> GetAllQuotes() 
        {
            using (var ctx = new ApplicationDbContext())
            {
                var quary = ctx
                    .Quotes
                    .Select(e => new QuoteList { BookTitle = e.Book.Title, AuthorName = e.Book.Author.FullName, QuotedText = e.QuoteText  });
                return quary.ToArray();
            }
        }

    }
}
