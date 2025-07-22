namespace DataStructures
{

    public class PseudoBinaryTree
    {
        internal class BtreeNode : Node<int>
        {
            public BtreeNode? left, right, parent;

            public BtreeNode(int val) : base(val)
            {
                left = null;
                right = null;
                parent = null;
            }
        }
        protected BtreeNode? RootNode;
        public bool Has(int val)
        {
            //return FindNode(Root)
        }
        private BtreeNode? FindNode(BtreeNode? current, int val)
        {
            /*
             * if(match)
             * return Node
             * if(val > node)
             * go right
             * if(val < node)
             * go left
             */
        }

        public void Add(int val)
        {
            //BtreeAdd(root, val)
        }

        virtual protected void BtreeAdd(BtreeNode current, int val)
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
        }

        public int? Remove(int val)
        {
            //return BTree Remove(root)
        }

        virtual protected BtreeNode? BtreeRemove(BtreeNode? removal)
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

        }


        public int Height()
        {
            //Return FindHeight(root)
        }

        protected int FindHeight(BtreeNode? node, int depth)
        {
            //return 1 + max(left child's height, right child's height
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