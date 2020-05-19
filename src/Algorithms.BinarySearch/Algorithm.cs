﻿namespace Algorithms.BinarySearch
{
    public static class Algorithm
    {
        /// <summary>
        /// Search for a number in a sorted array of integers.
        /// Complexity: O(log(n))
        /// </summary>
        /// <returns>The index of an occurence of the number if found, otherwise -1.</returns>
        public static int BinarySearch(int[] numbers, int value)
        {
            return BinarySearch(numbers, value);
        }

        /// <summary>
        /// Search for a number in a sorted array of integers.
        /// Complexity: O(log(n))
        /// </summary>
        /// <returns>The index of the first occurence of the number if found, otherwise -1.</returns>
        public static int FindFirst(int[] numbers, int value)
        {
            return BinarySearch(numbers, value, findFirst: true);
        }

        /// <summary>
        /// Search for a number in a sorted array of integers.
        /// Complexity: O(log(n))
        /// </summary>
        /// <returns>The index of the last occurence of the number if found, otherwise -1.</returns>
        public static int FindLast(int[] numbers, int value)
        {
            return BinarySearch(numbers, value, findFirst: false);
        }

        private static int BinarySearch(int[] numbers, int value, bool? findFirst = null)
        {
            var result = -1;

            var left = 0;
            var right = numbers.Length - 1;

            while (left <= right)
            {
                var middle = left + (right - left) / 2;

                if (value == numbers[middle])
                {
                    result = middle;

                    if (findFirst.HasValue)
                    {
                        if (findFirst.Value)
                        {
                            right = middle - 1;
                        }
                        else
                        {
                            left = middle + 1;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                else if (value < numbers[middle])
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
