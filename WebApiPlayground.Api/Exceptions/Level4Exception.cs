using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
