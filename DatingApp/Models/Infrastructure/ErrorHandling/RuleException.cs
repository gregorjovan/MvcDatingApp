using System;
using System.Collections.Specialized;

namespace DatingApp.Models.Infrastructure.ErrorHandling
{
    public class RuleException : Exception
    {
        public NameValueCollection Errors { get; private set; }

        public RuleException(string key, string value)
        {
            Errors = new NameValueCollection { { key, value } };
        }
        public RuleException(NameValueCollection errors)
        {
            Errors = errors;
        }
    }
}