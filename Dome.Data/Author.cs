using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dome.Data
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        [Required]
        public string FullName { get; set; }

        public Guid UserId { get; set; }
    }
}
