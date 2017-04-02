using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Arrays_DS {
    class Program {
        static int? getValue(int[][] matrix, int row, int col) {
            if (row < 0 || row >= 6 || col < 0 || col >= 6) {
                return null;
            }
            return matrix[row][col];
        }

        static int hourglass(int[][] matrix) {
            int max = int.MinValue;
            for (int row = 0; row < 6; row++) {
                for (int col = 0; col < 6; col++) {
                    // top
                    int? a = getValue(matrix, row - 1, col);
                    if (a == null) {
                        continue;
                    }
                    // top right
                    int? b = getValue(matrix, row - 1, col + 1);
                    if (b == null) {
                        continue;
                    }
                    // center
                    int? c = getValue(matrix, row, col);
                    if (c == null) {
                        continue;
                    }
                    // bottom right
                    int? d = getValue(matrix, row + 1, col + 1);
                    if (d == null) {
                        continue;
                    }
                    // bottom
                    int? e = getValue(matrix, row + 1, col);
                    if (e == null) {
                        continue;
                    }
                    // bottom left
                    int? f = getValue(matrix, row + 1, col - 1);
                    if (f == null) {
                        continue;
                    }
                    // top left
                    int? g = getValue(matrix, row - 1, col - 1);
                    if (g == null) {
                        continue;
                    }
                    int? sum = a + b + c + d + e + f + g;
                    max = Math.Max(max, sum.Value);
                }
            }
            return max;
        }

        static void Main(string[] args) {
            int[][] matrix = new int[6][];
            for (int row = 0; row < 6; row++) {
                string[] line = Console.ReadLine().Split(' ');
                matrix[row] = Array.ConvertAll(line, Int32.Parse);
            }

            Console.WriteLine(hourglass(matrix));

            Console.ReadLine();
        }
    }
}
