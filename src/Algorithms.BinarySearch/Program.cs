using System;

namespace Algorithms.BinarySearch
{
    public class Program
    {
        public static void Main()
        {
            var numbers = new int[] { 1, 5, 5, 7, 12, 13, 17, 17, 21, 25 };
            var result = BinarySearch(numbers, 17);

            Console.WriteLine(result);
        }

        /// <summary>
        /// Search for a number in a sorted array of integers.
        /// </summary>
        /// <returns>The index of the first occurence of the number if found, otherwise -1.</returns>
        public static int BinarySearch(int[] numbers, int number)
        {
            var result = -1;

            var left = 0;
            var right = numbers.Length - 1;

            while (left <= right)
            {
                var middle = left + (right - left) / 2;

                if (number == numbers[middle])
                {
                    result = middle;
                    right = middle - 1;
                }
                else if (number < numbers[middle])
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            return result;
        }
    }
}
