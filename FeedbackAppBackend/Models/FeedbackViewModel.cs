using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackAppBackend.Models
{
    public class FeedbackViewModel 
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
    }
}
