using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagonalDifference {
    class Program {
        static void Main(string[] args) {
            int rows = Convert.ToInt32(Console.ReadLine());
            int[][] matrix = new int[rows][];
            for (int r = 0; r < rows; r++) {
                string[] columns = Console.ReadLine().Split(' ');
                matrix[r] = Array.ConvertAll(columns, Int32.Parse);
            }
            int d1 = 0;
            for (int i = 0; i < rows; ++i) {
                d1 += matrix[i][i];
                Console.WriteLine("d1: " + matrix[i][i].ToString());
            }

            int d2 = 0;
            for (int i = 0; i < rows; ++i) {
                d2 += matrix[rows - 1 - i][i];
                Console.WriteLine("d2: " + matrix[i][rows - 1 - i].ToString());
            }

            Console.WriteLine();
            Console.WriteLine("sd1: " + d1.ToString());
            Console.WriteLine("sd2: " + d2.ToString());
            Console.WriteLine();
            Console.WriteLine("dif: " + Math.Abs(d1 - d2).ToString());

            Console.ReadLine();
        }
    }
}
