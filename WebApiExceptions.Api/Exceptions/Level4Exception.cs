using System;

namespace WebApiPlayground.Api.Exceptions
{
    public class Level4Exception : Exception
    {
        public Level4Exception(string message) : base(message)
        {
        }

        public Level4Exception(string message, Exception ex) : base(message, ex)
        {
        }
    }
}