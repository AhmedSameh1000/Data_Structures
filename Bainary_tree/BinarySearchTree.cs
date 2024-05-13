using System.Collections.Specialized;
using System.Diagnostics;
using System.Xml.Schema;

namespace Bainary_tree
{
    public class BinarySearchTree
    {
        public Node root { get; set; }

        public BinarySearchTree()
        {
        }

        public void Add(int value)
        {
            AddLeafPrivate(value, root);
        }

        private void AddLeafPrivate(int value, Node node)
        {
            if (root is null)
            {
                root = new Node(value);
            }
            else if (value < node.data)
            {
                if (node.left != null)
                {
                    AddLeafPrivate(value, node.left);
                }
                else
                {
                    node.left = new Node(value);
                }
            }
            else if (value > node.data)
            {
                if (node.right != null)
                {
                    AddLeafPrivate(value, node.right);
                }
                else
                {
                    node.right = new Node(value);
                }
            }
            else
            {
                Console.WriteLine("Value Already Added in the tree");
            }
        }

        public void PrintInOrder()
        {
            PrintInOrderPrivate(root);
        }

        public Node FindByValue(int value)
        {
            return ReturnNodePrivate(value, root);
        }

        private Node ReturnNodePrivate(int value, Node node)
        {
            if (node is null)
            {
                return null;
            }
            if (node.data == value)
            {
                return node;
            }
            else
            {
                if (value < node.data)
                {
                    return ReturnNodePrivate(value, node.left);
                }
                else
                {
                    return ReturnNodePrivate(value, node.right);
                }
            }
        }

        private void PrintInOrderPrivate(Node root)
        {
            if (root is null)
                return;

            if (root.left != null)
            {
                PrintInOrderPrivate(root.left);
            }

            Console.WriteLine(root.data);

            if (root.right != null)
            {
                PrintInOrderPrivate(root.right);
            }
        }

        public Node ReturnRootValue()
        {
            if (root is null)
                return null;

            return root;
        }

        public void Print(int value)
        {
            var node = FindByValue(value);

            if (node is null)
            {
                Console.WriteLine("this Value is NotFound");
                return;
            }

            Console.WriteLine($"Parent Node is {node.data}");

            if (node.left is null)
            {
                Console.WriteLine("Left is null");
            }
            else
            {
                Console.WriteLine($"Left is {node.left.data}");
            }
            if (node.right is null)
            {
                Console.WriteLine("right is null");
            }
            else
            {
                Console.WriteLine($"Left is {node.right.data}");
            }
        }

        public void RemoveNode(int value)
        {
            RemoveNodePrivate(value, root);
        }

        private void RemoveNodePrivate(int value, Node parent)
        {
            if (root is null)
                return;

            if (root.data == value)
            {
                RemoveRootMatch();
            }
            else
            {
                if (value < parent.data && parent.left != null)
                {
                    if (parent.left.data == value)
                    {
                        RemoveMatch(parent, parent.left, true);
                    }
                    else
                    {
                        RemoveNodePrivate(value, parent.left);
                    }
                }
                else if (value > parent.data && parent.right != null)
                {
                    if (parent.right.data == value)
                    {
                        RemoveMatch(parent, parent.right, false);
                    }
                    else
                    {
                        RemoveNodePrivate(value, parent.right);
                    }
                }
                else
                {
                    Console.WriteLine($"value {value} is not found");
                }
            }
        }

        private void RemoveMatch(Node parent, Node match, bool left)
        {
            if (root is null)
                return;

            Node nodeToDel;

            var matchvalue = match.data;

            int smallestinRight;

            if (match.left is null && match.right is null)
            {
                nodeToDel = match;
                if (left)
                {
                    parent.left = null;
                }
                else
                {
                    parent.right = null;
                }
                nodeToDel = null;
            }
            else if (match.left is null && match.right is not null)
            {
                if (left)
                {
                    parent.left = match.right;
                }
                else
                {
                    parent.right = match.right;

                    match.right = null;
                }
            }
            else if (match.left is not null && match.right is null)
            {
                if (left)
                {
                    parent.left = match.left;
                }
                else
                {
                    parent.right = match.left;

                    match.right = null;
                }
            }
            else
            {
                smallestinRight = FindSmallesValue().data;

                RemoveNodePrivate(smallestinRight, match);

                match.data = smallestinRight;
            }
        }

        private void RemoveRootMatch()
        {
            if (root is null)
                return;

            int smallesTinSubTree = FindSmallesValue(root.right).data;

            var node = root;
            var value = root.data;

            if (root.left is null && root.right is null)
            {
                root = null;
                node = null;
            }
            else if (root.left is null && root.right is not null)
            {
                root = root.right;
                node.right = null;
                node = null;
            }
            else if (root.left is not null && root.right is null)
            {
                root = root.left;
                node.left = null;
                node = null;
            }
            else
            {
                RemoveNodePrivate(smallesTinSubTree, root);
                root.data = smallesTinSubTree;
            }
        }

        public Node FindSmallesValue(Node node = null)
        {
            return FindSmallesValuePrivate(node != null ? node : root);
        }

        private Node FindSmallesValuePrivate(Node node)
        {
            if (node is null)
                return null;

            if (node.left is null)
            {
                return node;
            }
            else
            {
                return FindSmallesValuePrivate(node.left);
            }
        }

        public Node FindGreatestValue()
        {
            return FindGreatestValuePrivate(root);
        }

        private Node FindGreatestValuePrivate(Node node)
        {
            if (node is null)
                return null;

            if (node.right is null)
                return node;
            else
            {
                return FindGreatestValuePrivate(node.right);
            }
        }
    }
}