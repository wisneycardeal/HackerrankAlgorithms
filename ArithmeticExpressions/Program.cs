using System;

namespace ArithmeticExpressions {
    class Program {

        static string expression(int[] numbers, int value, int index) {
            value %= 101;
            if (index == numbers.Length)
                return value == 0 ? "" : null;
            
            string result;
            int number = numbers[index];
            int next = index + 1;

            result = expression(numbers, value * number, next);

            if (result != null)
                return "*" + numbers[index] + result;

            result = expression(numbers, value + number, next);

            if (result != null)
                return "+" + numbers[index] + result;

            result = expression(numbers, value - number, next);

            if (result != null)
                return "-" + numbers[index] + result;

            return null;
        }

        static void Main(String[] args) {

            int q = Convert.ToInt32(Console.ReadLine());

            string[] strNumbers = Console.ReadLine().Split(' ');

            int[] numbers = Array.ConvertAll(strNumbers, Int32.Parse);

            Console.WriteLine(numbers[0] + expression(numbers, numbers[0], 1));

            Console.ReadLine();
        }
    }
}
