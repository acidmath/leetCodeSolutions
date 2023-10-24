using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePractice {
    internal class Problem25_ValidateBinarySearchTree : Problem {

        /*
        Given the root of a binary tree, determine if it is a valid binary search tree (BST).

        A valid BST is defined as follows:

        The left subtree of a node contains only nodes with keys less than the node's key.
        The right subtree of a node contains only nodes with keys greater than the node's key.
        Both the left and right subtrees must also be binary search trees. 

        Example 1:
        Input: root = [2,1,3]
        Output: true

        Example 2:
        Input: root = [5,1,4,null,null,3,6]
        Output: false
        Explanation: The root node's value is 5 but its right child's value is 4. 

        Constraints:
        The number of nodes in the tree is in the range [1, 104].
        -2^31 <= Node.val <= 2^31 - 1
        */

        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        private TreeNode GenerateInput(int exampleNumber) {

            switch (exampleNumber) {

                case 1: return new TreeNode(2, new TreeNode(1), new TreeNode(3));
                case 2: return new TreeNode(5, new TreeNode(1), new TreeNode(4, new TreeNode(3), new TreeNode(6)));
                case 3: return new TreeNode(5, new TreeNode(4), new TreeNode(6, new TreeNode(3), new TreeNode(7)));
                default: return null;

            }

        }

        private void printTree(TreeNode node) {

            if (node == null) return;

            Console.Write(node.val);
            printTree(node.left);
            printTree(node.right);            

        }

        internal override void Run() {

            TreeNode node = GenerateInput(3);

            Console.WriteLine("input");
            Console.Write('[');
            printTree(node);
            Console.WriteLine(']');
            Console.WriteLine($"Valid: {IsValid(node)}");

        }

        internal bool IsValid(TreeNode node) {

            return IsValid(node, (long)int.MinValue-1, (long)int.MaxValue+1);

        }

        internal bool IsValid(TreeNode node, long min, long max) {

            if (node.left == null && node.right == null) return node.val > min && node.val < max;
            if (node.left == null) return node.val > min && IsValid(node.right, node.val, max);
            if (node.right == null) return node.val < max && IsValid(node.left, min, node.val);

            return IsValid(node.left, min, node.val)
                && IsValid(node.right, node.val, max)
                && node.val > min 
                && node.val < max;

        }

    }

}
