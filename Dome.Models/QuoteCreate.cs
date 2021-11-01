using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dome.Models
{
    public class QuoteCreate
    {
        public int BookId { get; set; }
        public Guid UserId { get; set; }
        public string QuoteText { get; set; }
    }
}
