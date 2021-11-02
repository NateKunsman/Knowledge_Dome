using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dome.Models
{
    public class BookCreate
    {
        [Required]
        public string Title { get; set; }

        public int BookLength { get; set; }

        public DateTime DatePublished { get; set; }

        public string ISBN { get; set; }

        public string ReadingLevel { get; set; }

        public int AuthorId { get; set; }

    }
}
