using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackAppBackend.EFC.Entities
{
    public class Feedback : BaseEntity
    {
        public string Subject { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
    }
}
