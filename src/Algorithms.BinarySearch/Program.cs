using System;
using static Algorithms.BinarySearch.Applications;

namespace Algorithms.BinarySearch
{
    public class Program
    {
        public static void Main()
        {
            CircularSearchTest();
        }

        private static void GetElementFrequencyTest()
        {
            var numbers = new int[] { 1, 5, 5, 7, 12, 12, 12, 13, 17, 17, 17, 17, 21, 25 };
            var result = GetElementFrequency(numbers, 17);

            Console.WriteLine(result);
        }

        private static void GetRightRotationsCountTest()
        {
            var numbers = new int[] { 5, 6, 7, 8, 9, 10, 11, 12, 1, 2, 3, 4 };
            var result = GetRightRotationsCount(numbers);

            Console.WriteLine(result);
        }

        private static void CircularSearchTest()
        {
            var numbers = new int[] { 5, 6, 7, 8, 9, 10, 11, 12, 1, 2, 3, 4 };
            var result = CircularSearch(numbers, 5);

            Console.WriteLine(result);
        }
    }
}
