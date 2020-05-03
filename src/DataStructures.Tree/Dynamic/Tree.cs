using System;

namespace DataStructures.Tree.Dynamic
{
    public class Tree<T>
    {
        private readonly TreeNode<T> _root;

        public Tree(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), "Value cannot be null.");
            }

            _root = new TreeNode<T>(value);
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                _root.AddChild(child._root);
            }
        }

        public TreeNode<T> Root => _root;
    }
}
