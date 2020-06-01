using System;
using System.Collections.Generic;
using System.Linq;
using DataStructures.Tree.Dynamic;

namespace DataStructures.Tree
{
    public class TreeOperations
    {
        public static void Main()
        {
            /* Tree structure:
             * 
             *       2
             *     /   \
             *    1     5
             *  / | \
             * 7  0  3
             * 
             */

            var tree =
                new Tree<int>(2,
                    new Tree<int>(1,
                        new Tree<int>(7),
                        new Tree<int>(0),
                        new Tree<int>(3)),
                    new Tree<int>(5));

            var result = FindBFS(tree.Root, 7);
            Console.WriteLine(result?.Value.ToString() ?? "Not found");
        }

        private static TreeNode<T> FindDfsRecursive<T>(TreeNode<T> node, T value)
        {
            if (node.Value.Equals(value))
            {
                // recursion bottom - the value is found
                return node;
            }

            TreeNode<T> result;
            foreach (var child in node.Children)
            {
                // search recursively for the value in each child of the node
                result = FindDfsRecursive(child, value);
                if (result != null)
                {
                    // the value is found
                    return result;
                }
            }

            // the value is not found
            return null;
        }

        private static TreeNode<T> FindDFS<T>(TreeNode<T> node, T value)
        {
            var stack = new Stack<TreeNode<T>>();
            stack.Push(node); // push the root node in the stack

            TreeNode<T> next;
            while (stack.Any())
            {
                next = stack.Pop();
                if (next.Value.Equals(value))
                {
                    // the value is found
                    return next;
                }
                else if (next.Children.Any())
                {
                    // push all children of the next node in the stack
                    foreach (var child in next.Children)
                    {
                        stack.Push(child);
                    }
                }
            }

            return null;
        }

        private static TreeNode<T> FindBFS<T>(TreeNode<T> node, T value)
        {
            var queue = new Queue<TreeNode<T>>();
            queue.Enqueue(node); // enqueue the root node in the queue

            TreeNode<T> next;
            while (queue.Any())
            {
                next = queue.Dequeue();
                if (next.Value.Equals(value))
                {
                    // the value is found
                    return next;
                }
                else if (next.Children.Any())
                {
                    // enqueue all children of the next node in the queue
                    foreach (var child in next.Children)
                    {
                        queue.Enqueue(child);
                    }
                }
            }

            return null;
        }
    }
}
