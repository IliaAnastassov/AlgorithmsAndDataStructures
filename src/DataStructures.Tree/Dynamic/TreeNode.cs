using System;
using System.Collections.Generic;

namespace DataStructures.Tree.Dynamic
{
    public class TreeNode<T>
    {
        private T _value;
        private bool _hasParent;
        private List<TreeNode<T>> _children;

        public TreeNode(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), "Value cannot be null.");
            }

            _value = value;
            _children = new List<TreeNode<T>>();
        }

        public T Value
        {
            get => _value;
            set => _value = value;
        }

        public int ChildrenCount => _children.Count;

        public void AddChild(TreeNode<T> child)
        {
            if (child == null)
            {
                throw new ArgumentNullException(nameof(child), "Value cannot be null.");
            }
            if (child._hasParent)
            {
                throw new ArgumentException("Child node already has a parent.", nameof(child));
            }

            child._hasParent = true;
            _children.Add(child);
        }

        public TreeNode<T> GetChild(int index)
        {
            return _children[index];
        }
    }
}
