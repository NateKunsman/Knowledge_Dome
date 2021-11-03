using Dome.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dome.Models
{
    public class BookDetails
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public int BookLength { get; set; }

        public string ReadingLevel { get; set; }

        public DateTime DatePublished { get; set; }

        public string ISBN { get; set; }

        public List<Author> AuthorName { get; set; }

        public List<Genre> Genres { get; set; }

        //public Guid OwnerId { get; set; }
    }
}
