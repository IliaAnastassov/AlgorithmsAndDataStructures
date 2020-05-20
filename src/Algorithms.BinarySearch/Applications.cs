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
        /// Returns the number of right rotations performed on a sorted array with no duplicates. 
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
                if (numbers[left] <= numbers[right])
                {
                    // the segment is sorted => the minimum is the left element
                    rotationsCount = left;
                    break;
                }

                var mid = left + (right - left) / 2;
                var prev = (mid - 1 + numbers.Length) % numbers.Length;

                if (numbers[mid] <= numbers[prev])
                {
                    // the minimum element (pivot) is always smaller then the previous element
                    rotationsCount = mid;
                    break;
                }

                // one of the segments of a circularly sorted array will always be sorted
                if (numbers[mid] <= numbers[right])
                {
                    // the right segment is sorted => the pivot is in the left segment
                    right = mid - 1;
                }
                else
                {
                    // the left segment is sorted => the pivot is in the right segment
                    left = mid + 1;
                }
            }

            return rotationsCount;
        }

        /// <summary>
        /// Searches for an element in a circularly sorted array with no duplicates
        /// and returns the index of the element if found, otherwise -1.
        /// </summary>
        public static int CircularSearch(int[] numbers, int value)
        {
            var result = -1;

            var left = 0;
            var right = numbers.Length - 1;

            while (left <= right)
            {
                var mid = left + (right - left) / 2;

                if (numbers[mid] == value)
                {
                    // the value is found
                    result = mid;
                    break;
                }

                // one of the segments of a circularly sorted array will always be sorted
                if (numbers[mid] <= numbers[right])
                {
                    // the right segment is sorted
                    if (numbers[mid] < value && value <= numbers[right])
                    {
                        // the value is in the right segment
                        left = mid + 1;
                    }
                    else
                    {
                        // the value is in the left segment
                        right = mid - 1;
                    }
                }
                else
                {
                    // the left segment is sorted
                    if (numbers[left] <= value && value < numbers[mid])
                    {
                        // the value is in the left segment
                        right = mid - 1;
                    }
                    else
                    {
                        // the value is in the right segment
                        left = mid + 1;
                    }
                }
            }

            return result;
        }
    }
}
