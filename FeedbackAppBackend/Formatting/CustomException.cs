using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackAppBackend.Formatting
{
    public class CustomException : ApplicationException
    {
        public CustomException(string message) : base(message)
        {
        }
    }
}
