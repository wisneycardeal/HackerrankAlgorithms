using System;
namespace Equals {
    class Program {
        static void distribute(Int32[] numbers, int increment) {
            for (int i = 0; i < numbers.Length - 1; i++) {
                numbers[i] += increment;
            }
        }

        static long operations(Int32[] numbers, long ops) {

            Array.Sort(numbers);
            long sum = long.MaxValue;
            for (int b = 0; b < 3; b++) {
                int current_sum = 0;
                for (int i = 0; i < numbers.Length; i++) {
                    int delta = numbers[i] - numbers[0] + b;
                    current_sum += (int)delta / 5 + delta % 5 / 2 + delta % 5 % 2 / 1;
                }
                sum = Math.Min(current_sum, sum);
            }
            return sum;
        }

        static void Main(string[] args) {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= t; i++) {
                Console.ReadLine();
                string[] strNumbers = Console.ReadLine().Split(' ');
                Int32[] numbers = Array.ConvertAll(strNumbers, Int32.Parse);

                Console.WriteLine(operations(numbers, 0));
            }
        }
    }
}