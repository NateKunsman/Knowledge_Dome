using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dome.Data
{
    public class Favorite
    {
        [Key]
        public int FavoriteId { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }

        public virtual Book Book { get; set; }

    }
}
