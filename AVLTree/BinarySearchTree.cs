namespace DataStructures
{

    public class BinaryTree
    {
        protected internal class BtreeNode : Node<int>
        {
            public BtreeNode? left, right, parent;
            public int data;

            public BtreeNode(int val) : base(val)
            {
                left = null;
                right = null;
                parent = null;
                data = val;
            }

            public int Data
            {
                get { return data; }
                set { data = value; }
            }
            public BtreeNode? Left
            {
                get { return left; }
                set { left = value; }
            }
            public BtreeNode? Right
            {
                get { return right; }
                set { right = value; }
            }
            public BtreeNode? Parent
            {
                get { return parent; }
                set { parent = value; }
            }
        }


        protected BtreeNode? RootNode;

        public BinaryTree()
        {
            RootNode = null;
        }
        public bool Has(int val)
        {
            if (FindNode(RootNode, val) != null)
            {
                return true;
            }
            return false;
        }
        protected BtreeNode? FindNode(BtreeNode? current, int val)
        {
            /*
             * if(match)
             * return Node
             * if(val > node)
             * go right
             * if(val < node)
             * go left
             */
            if (current == null)
            {
                return null;
            }
            if (current.Data == val)
            {
                return current;
            }
            else if (val > current.Data)
            {
                return FindNode(current.Right, val);
            }
            else if (val < current.Data)
            {
                return FindNode(current.Left, val);
            }
            else
            {
                return null;
            }
        }

        public void Add(int val)
        {
            if (RootNode == null)
            {
                RootNode = new BtreeNode(val);
            }
            else
            {
                BtreeAdd(RootNode, val);
            }

        }

        private void BtreeAdd(BtreeNode current, int val)
        {

            /*
             * if(val > node)
             * Check right:
             * if node has right child -> BtreeAdd(right,val)
             * if node's right child is null -> add val as right child
             * else (val < node)
             * Check left:
             * Same as Check right but with the left child of current
             */
            if (val > current.Data)
            {
                if (current.Right != null)
                {
                    BtreeAdd(current.Right, val);
                }
                else
                {
                    current.Right = new BtreeNode(val);
                    current.Right.Parent = current;
                }
            }
            else
            {
                if (current.Left != null)
                {
                    BtreeAdd(current.Left, val);
                }
                else
                {
                    current.Left = new BtreeNode(val);
                    current.Left.Parent = current;
                }
            }
        }

        public int? Remove(int val)
        {
            return BtreeRemove(RootNode, val)?.Data;
        }

        private BtreeNode? BtreeRemove(BtreeNode current, int val)
        {
            //If removal is null, return null (item doesnt exist)
            /*
             * if(0 children)
             * nuke, no extra work needed
             * if(1 child)
             * nuke, then move child up
             * if(2 children)
             * find succcessor
             * update childre nodes & success to point to each other approriately)
             * nuke original node
             * 
             */
            BtreeNode? target = FindNode(current, val);
            if (target == null)
            {
                return null;
            }

            //Target has no children
            if (target.Left == null && target.Right == null)
            {
                if (target.Parent == null)
                {
                    RootNode = null;
                }
                else if (target == target.Parent.Left)
                {
                    target.Parent.Left = null;
                }
                else
                {
                    target.Parent.Right = null;
                }
            }

            //Target has only left child
            else if (target.Left != null && target.Right == null)
            {
                if (target.Parent == null)
                {
                    RootNode = target.Left;
                    target.Left.Parent = null;
                }
                else
                {
                    if (target == target.Parent.Left)
                    {
                        target.Parent.Left = target.Left;
                    }
                    else
                    {
                        target.Parent.Right = target.Left;
                    }
                    target.Left.Parent = target.Parent;

                }
            }
            //Target has only right child
            else if (target.Right != null && target.Left == null)
            {
                if (target.Parent == null)
                {
                    RootNode = target.Right;
                    target.Right.Parent = null;
                }
                else
                {
                    if (target == target.Parent.Left)
                    {
                        target.Parent.Left = target.Right;
                    }
                    else
                    {
                        target.Parent.Right = target.Right;
                    }
                    target.Right.Parent = target.Parent;
                }
            }
            //Target has two children
            else if (target.Left != null && target.Right != null)
            {
                BtreeNode successor = FindSuccessor(target);
                target.Data = successor.Data;
                BtreeRemove(successor, successor.Data);
            }
            return target;
        }

        /*
         * We hunt for the leftmost child of the right node
         */
        private static BtreeNode FindSuccessor(BtreeNode DeadNode)
        {
            /*
             * Find a successor node to the one being removed
             * 2 approaches:
             * find left most child of DeadNode's right child
             * OR
             * find right most child of DeadNode's left child
             */

            BtreeNode right = DeadNode.Right;
            while (right?.Left != null)
            {
                right = right.Left;
            }
            return right;
        }


        public int Height()
        {
            if (RootNode == null)
            {
                return -1;
            }
            return FindHeight(RootNode);
        }

        protected int FindHeight(BtreeNode? node)
        {
            //return 1 + max(left child's height, right child's height
            if (node == null)
            {
                return -1;
            }
            else
            {
                return 1 + Math.Max(FindHeight(node.Left), FindHeight(node.Right));
            }
        }

        private List<BtreeNode> BfirstGather(BtreeNode? root)
        {
            var list = new List<BtreeNode>();
            var queue = new Queue<BtreeNode>();

            if (root != null)
            {
                queue.Enqueue(root);
            }

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                list.Add(node);

                if (node.Left != null)
                    queue.Enqueue(node.Left);
                if (node.Right != null)
                    queue.Enqueue(node.Right);
            }

            return list;
        }


        override public String ToString()
        {
            String result = "";

            foreach (var node in BfirstGather(RootNode))
            {
                int val = node.Data;
                if (node.parent == null)
                {
                    result += "(root | " + val + ") ";
                }
                else
                {
                    result += "(" + node.parent.Data + " | " + val + ") ";
                }
            }
            return result;

        }
    }
}