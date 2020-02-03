using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixes.Classes
{
    class MatrixInvalidSizeException : Exception
    {
        public MatrixInvalidSizeException() : base()
        {
        }

        public MatrixInvalidSizeException(string message) : base(message)
        {
        }        
    }

    class MatrixInvalidMultiplyException : Exception
    {
        public MatrixInvalidMultiplyException() : base()
        {
        }

        public MatrixInvalidMultiplyException(string message) : base(message)
        {
        }
    }
}
