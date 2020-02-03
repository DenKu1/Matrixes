using Matrixes.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixes
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix a = new Matrix(new int[3, 3] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } });
            Matrix b = new Matrix(new int[3, 3] { { 2, 1, 2 }, { 1, 2, 1 }, { 2, 1, 2 } });
            Matrix c = new Matrix(new int[3, 2] { { 3, 3 }, { 3, 3 }, { 3, 3 } });

            Console.WriteLine(a + b);
            Console.WriteLine(a - b);
            Console.WriteLine(a * b);
            Console.WriteLine(a * c);

            Console.ReadKey();
        }
    }
}
