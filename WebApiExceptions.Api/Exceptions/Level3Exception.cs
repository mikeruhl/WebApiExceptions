using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiPlayground.Api.Exceptions
{
    public class Level3Exception : Exception
    {
        public Level3Exception(string message) : base(message)
        {
        }

        public Level3Exception(string message, Exception ex) : base(message, ex)
        {
        }
        
    }
}
