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
    public class QuoteController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post(QuoteCreate quote)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateQuoteService();
            if (!service.CreateQuote(quote))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Get()
        {
            QuoteService quoteService = CreateQuoteService();
            var quotes = quoteService.GetAllQuotes();
            return Ok(quotes);
        }
        private QuoteService CreateQuoteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var quoteService = new QuoteService(userId);
            return quoteService;
        }
    }
}
