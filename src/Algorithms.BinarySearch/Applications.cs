using static Algorithms.BinarySearch.Algorithm;

namespace Algorithms.BinarySearch
{
    public static class Applications
    {
        /// <summary>
        /// Returns the count of occurences of an element in a sorted array.
        /// </summary>
        public static int GetElementFrequency(int[] numbers, int value)
        {
            var frequency = -1;

            var first = FindFirst(numbers, value);
            if (first != -1)
            {
                var last = FindLast(numbers, value);
                frequency = last - first + 1;
            }

            return frequency;
        }

        /// <summary>
        /// Returns the number of right rotations performed on a sorted array. 
        /// The number of right rotations is the index of the minimum element of the array.
        /// 0 1 2 3 4 5 6 7 8
        /// 6 7 8 0 1 2 3 4 5
        /// </summary>
        public static int GetRightRotationsCount(int[] numbers)
        {
            var rotationsCount = -1;

            var left = 0;
            var right = numbers.Length - 1;

            while (left <= right)
            {
                if (numbers[left] < numbers[right])
                {
                    rotationsCount = left;
                    break;
                }

                var mid = left + (right - left) / 2;
                var prev = (mid - 1 + numbers.Length) % numbers.Length;

                if (numbers[mid] < numbers[prev])
                {
                    rotationsCount = mid;
                    break;
                }
                else if (numbers[mid] < numbers[right])
                {
                    right = mid - 1;
                }
                else if (numbers[mid] > numbers[left])
                {
                    left = mid + 1;
                }
            }

            return rotationsCount;
        }
    }
}
