using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixes.Classes
{
    class MatrixInvalidSizeException : Exception
    {
        public MatrixInvalidSizeException(string message) : base(message)
        {
        }
    }
}
