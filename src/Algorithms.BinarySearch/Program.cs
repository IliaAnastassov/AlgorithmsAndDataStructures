using System;
using static Algorithms.BinarySearch.Applications;

namespace Algorithms.BinarySearch
{
    public class Program
    {
        public static void Main()
        {
            var numbers = new int[] { 1, 5, 5, 7, 12, 12, 12, 13, 17, 17, 17, 17, 21, 25 };
            var result = GetElementFrequency(numbers, 17);

            Console.WriteLine(result);
        }
    }
}
