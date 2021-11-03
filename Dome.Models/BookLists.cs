using Dome.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dome.Models
{
    public class BookLists
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public ICollection<AuthorList> Authors { get; set; } = new List<AuthorList>();

        public ICollection<GenreListItem> Genres { get; set; } = new List<GenreListItem>();
    }
}
