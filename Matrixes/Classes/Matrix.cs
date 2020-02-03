using System;

namespace Matrixes.Classes
{
    class Matrix : ICloneable
    {
        public readonly int m;

        public readonly int n;

        private int[,] _value;

        public int[,] Value
        {
            get
            {
                return _value; 
            }

            set
            {
                if (value is null)
                    throw new NullReferenceException();                

                if (value.GetLength(0) != m || value.GetLength(1) != n)                
                    throw new MatrixInvalidSizeException("New matrix value has invalid size!");                

                _value = value;
            }
        }        

        public Matrix(int m, int n)
        {
            if (m == 0 || n == 0)            
                throw new MatrixInvalidSizeException("Matrix can`t have zero columns or rows!");            

            this.m = m;
            this.n = n;

            _value = new int[m, n];          
        }

        public Matrix(int[,] matrix)
        {
            if (matrix is null)
                throw new NullReferenceException();

            m = matrix.GetLength(0);
            n = matrix.GetLength(1);

            if (m == 0 || n == 0)
                throw new MatrixInvalidSizeException("Matrix can`t have zero columns or rows!");

            _value = matrix;
        }

        public int this[int i, int j]
        {
            get
            {
                CheckRange(i, j);

                return Value[i, j];
            }

            set
            {
                CheckRange(i, j);

                Value[i, j] = value;
            }
        }

        private void CheckRange(int i, int j)
        {
            if (i >= m || j >= n)
                throw new IndexOutOfRangeException();
        }

        private static void CheckIsNull(Matrix m1, Matrix m2)
        {
            if (m1 is null || m2 is null)            
                throw new NullReferenceException();            
        }

        private static void CheckSizeEquality(Matrix m1, Matrix m2)
        {           
            if (m1.m != m2.m || m1.n != m2.n)            
                throw new MatrixInvalidSizeException("Can`t perform actions on matrixes with different size!");    
        }

        public static Matrix SumUpMatrixes(Matrix m1, Matrix m2)
        {
            CheckIsNull(m1, m2);

            CheckSizeEquality(m1, m2);

            Matrix result = new Matrix(m1.m, m1.n);

            for (int i = 0; i < m1.m; i++)
            {
                for (int j = 0; j < m1.n; j++)
                {
                    result[i, j] = m1[i, j] + m2[i, j];
                }
            }

            return result;
        }

        public static Matrix SubtractMatrixes(Matrix m1, Matrix m2)
        {
            CheckIsNull(m1, m2);

            CheckSizeEquality(m1, m2);

            Matrix result = new Matrix(m1.m, m1.n);

            for (int i = 0; i < m1.m; i++)
            {
                for (int j = 0; j < m1.n; j++)
                {
                    result[i, j] = m1[i, j] - m2[i, j];
                }
            }

            return result;
        }

        public static Matrix MultiplyMatrixes(Matrix m1, Matrix m2)
        {
            CheckIsNull(m1, m2);

            if (m1.n != m2.m)
            {
                throw new MatrixInvalidMultiplyException("Number of columns in the first matrix is ​​not equal" +
                    " to the number of rows in the second matrix!!");
            }

            Matrix result = new Matrix(m1.m, m2.n);

            for (int i = 0; i < m1.m; i++)
            {
                for (int j = 0; j < m2.n; j++)
                {
                    result[i, j] = 0;

                    for (int k = 0; k < m1.n; k++)
                    {
                        result[i, j] += m1[i, k] * m2[k, j];
                    }
                }
            }

            return result;
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            return SumUpMatrixes(m1, m2);
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            return SubtractMatrixes(m1, m2);
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            return MultiplyMatrixes(m1, m2);
        }

        public override string ToString()
        {          
            string strMatrix = "";

            for (int i = 0; i < m; i++)
            {
                strMatrix += "( ";

                for (int j = 0; j < n; j++)
                {
                    strMatrix += this[i, j].ToString() + " ";
                }

                strMatrix += "), ";
            }

            return strMatrix.Substring(0, strMatrix.Length - 2);
        }

        public object Clone()
        {
            return new Matrix((int[,])Value.Clone());
        }
    }
}
