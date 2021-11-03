using Dome.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dome.Models
{
    public class FavoriteLists
    {
        //public Guid UserId { get; set; }
        public string BookTitle { get; set; }
        public string AuthorName { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
