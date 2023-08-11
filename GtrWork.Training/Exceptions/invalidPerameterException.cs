using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GtrWork.Training.Exceptions
{
    public class invalidPerameterException : Exception
    {
        public invalidPerameterException(string message)
            : base(message)
        {

        }
    }
}
