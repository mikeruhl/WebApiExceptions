using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
