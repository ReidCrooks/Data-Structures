using System.Runtime.CompilerServices;
using System.Xml.Schema;

namespace DataStructures
{
    public class AVLTree : BinaryTree
    {
        public AVLTree()
        {
        }

        public void AVLAdd(int val)
        {
            Add(val);
            var inserted = FindNode(RootNode, val);

            BtreeNode current = inserted;

            //Check the entire tree for restructuring
            while (current != null)
            {
                if (!IsBalanced(current))
                {
                    Restructure(current);
                    break;
                }
                current = current.Parent;
            }
        }

        public new int? Remove(int val)
        {
            var removedNode = FindNode(RootNode, val);
            var result = base.Remove(val);

            if (removedNode == null)
                return result;

            BtreeNode current = removedNode.Parent;

            while (current != null)
            {
                if (!IsBalanced(current))
                {
                    Restructure(current);
                }
                current = current.Parent;
            }

            return result;
        }


        protected void Restructure(BtreeNode x)
        {
            //Find taller child of x
            BtreeNode y;
            if (FindHeight(x.Left) > FindHeight(x.Right))
            {
                y = x.Left;
            }
            else
            {
                y = x.Right;
            }
            //Find taller child of y
            BtreeNode z;
            if (FindHeight(y.Left) > FindHeight(y.Right))
            {
                z = y.Left;
            }
            else
            {
                z = y.Right;
            }

            //Check for line vs zigzag pattern
            //line
            if ((y == x.Left && z == y.Left) || (y == x.Right && z == y.Right))
            {
                Rotate(y);
            }

            //zigzag
            else if ((y == x.Left && z == y.Right) || (y == x.Right && z == y.Left))
            {
                Rotate(z);
                Rotate(z);
            }
        }

        protected void Rotate(BtreeNode x)
        {
            //Left line
            if (x == x.Parent.Left)
            {
                var oldParent = x.Parent;
                //Reassign root node
                if (oldParent.Parent == null)
                {
                    RootNode = x;
                    x.Parent = null;
                }
                //Reassign grandparents
                else
                {
                    var grand = oldParent.Parent;
                    if (oldParent == grand.Left)
                    {
                        grand.Left = x;
                    }
                    else
                    {
                        grand.Right = x;
                    }
                    x.Parent = grand;
                }
                //Core rotation
                BtreeNode temp = x.Right;
                x.Right = oldParent;
                oldParent.Parent = x;
                oldParent.Left = temp;
                if (temp != null)
                {
                    temp.Parent = oldParent;
                }
            }
            //Same as above but mirrored to right line
            else
            {
                var oldParent = x.Parent;

                if (oldParent.Parent == null)
                {
                    RootNode = x;
                    x.Parent = null;
                }
                else
                {
                    var grand = oldParent.Parent;
                    if (oldParent == grand.Left)
                    {
                        grand.Left = x;
                    }
                    else
                    {
                        grand.Right = x;
                    }
                    x.Parent = grand;
                }

                BtreeNode temp = x.Left;
                x.Left = oldParent;
                oldParent.Parent = x;
                oldParent.Right = temp;
                if (temp != null)
                {
                    temp.Parent = oldParent;
                }
            }
        }

        private bool IsBalanced(BtreeNode x)
        {
            int left = FindHeight(x.Left);
            int right = FindHeight(x.Right);

            if (Math.Abs(left - right) <= 1)
            {
                return true;
            }
            return false;
        }
    }
}