using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dome.Data
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }
        
        public int BookLength { get; set; }

        public string ReadingLevel { get; set; }

        public DateTime DatePublished { get; set; }

        public string ISBN { get; set; }

        public virtual ICollection<BookGenre> Genres { get; set; } = new List<BookGenre>();

        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        //public Guid OwnerId { get; set; } 

    }
}
