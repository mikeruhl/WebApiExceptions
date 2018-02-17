using System;

namespace WebApiPlayground.Api.Exceptions
{
    public class Level2Exception : Exception
    {
        public Level2Exception(string message) : base(message)
        {
        }

        public Level2Exception(string message, Exception ex) : base(message, ex)
        {
        }
    }
}