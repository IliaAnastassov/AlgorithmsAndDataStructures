using System;
using System.Linq;

namespace Algorithms.BinarySearch
{
    public class Program
    {
        public static void Main()
        {
            var numbers = Enumerable.Range(1, 100).ToArray();
            var result = BinarySearch(numbers, 7);

            Console.WriteLine(result);
        }

        public static int BinarySearch(int[] numbers, int number)
        {
            var left = 0;
            var right = numbers.Length - 1;

            while (left <= right)
            {
                var middle = left + (right - left) / 2;

                if (number == numbers[middle])
                {
                    return middle;
                }

                if (number < numbers[middle])
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            return -1;
        }
    }
}
