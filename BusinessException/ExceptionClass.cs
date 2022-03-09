using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessException
{
    public class ExceptionClass : Exception
    {
        public ExceptionClass()
        {

        }

        public ExceptionClass(string message) : base(message)
        {

        }
    }
}
