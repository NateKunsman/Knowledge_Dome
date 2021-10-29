using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dome.Models
{
    public class FavoritesEdit
    {
        public int FavoritesId { get; set; }
        public int BookId { get; set; }
        public Guid UserId { get; set; }
    }
}
