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
                PrintListNode(listNode1, "List 1: ");
                PrintListNode(listNode2, "List 2: ");
                ListNode? mergedListNode = MergeNodes(listNode1, listNode2);
                PrintListNode(mergedListNode, "Merged List: ");
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

            if (!TryParseInput(input, out listNode1)) {
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
                    if (lastNode != null) listNode.Next = lastNode;
                    lastNode = listNode;
                }
                return true;
            }
            catch (Exception) {
                return false;
            }
        }

        private void PrintListNode(ListNode? listNode, string label) {
            Console.Write(label);
            while (listNode != null) {
                Console.Write(listNode.Value);
                listNode = listNode.Next;
            }
            Console.WriteLine();
        }
                
        private ListNode? MergeNodes(ListNode? listNode1, ListNode? listNode2) {
            
            if (listNode1 == null) return listNode2;
            if (listNode2 == null) return listNode1;
            ListNode listNode = new();

            if (listNode1.Value > listNode2.Value) {
                SetListNodeValue(listNode, listNode2.Value);
                listNode2 = listNode2.Next;
            }
            else {
                SetListNodeValue(listNode, listNode1.Value);
                listNode1 = listNode1.Next;
            }
                
            listNode.Next = MergeNodes(listNode1, listNode2);
            
            return listNode;
        }

        private void SetListNodeValue(ListNode? listNode, int value) {
            if (listNode == null) listNode = new ListNode(value);
            else listNode.Value = value;
        }
    }

    // typically I would put a new class in a new file, but the purpose of this repo is more algorithm focused rather than class/file organization
    public class ListNode {
        public int Value;
        public ListNode? Next;

        public ListNode(int val = 0, ListNode? next = null) {
            Value = val;
            Next = next;
        }
    }

}