using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePractice {

    /// <summary>
    /// Solution to <see href="https://leetcode.com/problems/merge-two-sorted-lists/description/">this problem</see>
    /// </summary>
    internal class MergeTwoSortedLists : Problem {

        /*
        Example 1:
        Input: list1 = [1,2,4], list2 = [1,3,4]
        Output: [1,1,2,3,4,4]
        
        Example 2:
        Input: list1 = [], list2 = []
        Output: []

        Example 3:
        Input: list1 = [], list2 = [0]
        Output: [0] 

        Constraints:
        The number of nodes in both lists is in the range [0, 50].
        -100 <= Node.val <= 100
        Both list1 and list2 are sorted in non-decreasing order.
        */
        internal override void Run() {
            if (TryGetInput(out ListNode? listNode1, out ListNode? listNode2)) {
                Console.Clear();
                Console.Write("List 1: ");
                while (listNode1 != null) {
                    Console.Write(listNode1.val);
                    listNode1 = listNode1.next;
                }
                Console.WriteLine();
                Console.Write("List 2: ");
                while (listNode2 != null) {
                    Console.Write(listNode2.val);
                    listNode2 = listNode2.next;
                }
            }
        }

        internal bool TryGetInput(out ListNode? listNode1, out ListNode? listNode2) {
            listNode1 = null;
            listNode2 = null;
            Console.WriteLine("Please enter the values of the first list separated by commas");
            string? input = Console.ReadLine();
            if (input == null) {
                Console.WriteLine("Malformed input not accepted");
                return false;
            }

            if(!TryParseInput(input, out listNode1)) {                
                Console.WriteLine("Malformed input not accepted");                
                return false;
            }

            Console.WriteLine("Please enter the values of the second list separated by commas");
            input = Console.ReadLine();
            if (input == null) {
                Console.WriteLine("Malformed input not accepted");
                return false;
            }

            if (!TryParseInput(input, out listNode2)) {
                Console.WriteLine("Malformed input not accepted");
                return false;
            }

            return true;
        }

        private bool TryParseInput(string input, out ListNode? listNode) {
            listNode = null;
            ListNode? lastNode = null;
            try {
                string[] nodeValues = input.Split(',');
                for (int i = nodeValues.Length - 1; i >= 0; i--) {
                    string nodeValue = nodeValues[i];
                    listNode = new ListNode(int.Parse(nodeValue));
                    if (lastNode != null) listNode.next = lastNode;
                    lastNode = listNode;
                }
                return true;
            }
            catch (Exception) {
                return false;
            }
        }
    }

    public class ListNode {
        public int val;
        public ListNode? next;

        public ListNode(int val = 0, ListNode? next = null) {
            this.val = val;
            this.next = next;
        }
    }
}