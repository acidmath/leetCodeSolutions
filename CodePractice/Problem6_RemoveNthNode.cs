using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePractice {

    /*
    Given the head of a linked list, remove the nth node from the end of the list and return its head. 

    Example 1:
    Input: head = [1,2,3,4,5], n = 2
    Output: [1,2,3,5]

    Example 2:
    Input: head = [1], n = 1
    Output: []

    Example 3:
    Input: head = [1,2], n = 1
    Output: [1] 

    Constraints:
    The number of nodes in the list is sz.
    1 <= sz <= 30
    0 <= Node.val <= 100
    1 <= n <= sz
 

    Follow up: Could you do this in one pass?
    */

    internal class Problem6_RemoveNthNode : Problem {

        

        /// <summary>
        /// Provided from question
        /// </summary>
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null) {
                this.val = val;
                this.next = next;
            }
        }

        /// <summary>
        /// I want to go through and essentially store the whole linked list, only then will i know the length.
        /// I am given just the first ListNode, so i have to follow the nexts around.
        /// The other thing i know is which one i want to cut off, so I could have a sort of buffer, and once the last item in the buffer has a null next, I know to not include the first item in the buffer.
        /// I can't tell if the problem wants an array or if it wants me to change the next value of the list node before the kicked-out listnode to the kicked-out listnode's next.
        /// I guess I should do both.
        /// </summary>
        internal override void Run() {

            int removalIndex = 2;
            int length = 2;
            ListNode node = generateHead(length);
            Console.WriteLine("input");
            while (node != null) {

                Console.Write(node.val);
                node = node.next;

            }
            Console.WriteLine();

            node = RemoveNodeAt(generateHead(length), removalIndex);

            Console.WriteLine("output");
            while (node != null) {

                Console.Write(node.val);
                node = node.next;

            }

        }

        /// <summary>
        /// make my own test cases
        /// </summary>        
        ListNode generateHead(int length) {

            if (length == 1) return new ListNode(1);
            else {

                ListNode tail = new ListNode(length);
                length--;
                ListNode head = new ListNode(length, tail);
                length--;

                while (length > 0) {

                    tail = head;
                    head = new ListNode(length, tail);
                    length--;

                }
                
                return new ListNode(1, tail);

            }

        }

        ListNode RemoveNodeAt(ListNode head, int removalIndex) {

            if (head==null || head.next == null) return null;

            ListNode newHead = null;
            ListNode newTail = null;
            ListNode[] buffer;
            int bufferCount = 0;

            buffer = new ListNode[removalIndex];

            ListNode node = head;
            while (node != null) {

                // spool up buffer while it's empty
                if (bufferCount < removalIndex) {
                    buffer[bufferCount++] = node;
                }
                // otherwise add the first listnode in the buffer to the tail of the new linked list and shift the buffer left
                else {

                    // setup the new head and tail if there is none
                    if (newHead == null) {

                        newHead = buffer[0];
                        newHead.next = null;
                        
                        newTail = newHead;

                    }
                    // move the tail up one
                    else {

                        newTail.next = buffer[0];
                        newTail = newTail.next;
                        newTail.next = null;

                    }

                    // shift the array to the left
                    for(int i=0; i< removalIndex-1;) {

                        buffer[i] = buffer[++i];

                    }

                    buffer[removalIndex - 1] = node;

                }

                // go to next node
                node = node.next;

            }

            // if new head is null, then we never got to leave the buffer
            // there are 2 cases
            // a single list node item, so we return null
            // we are removing the item at the very beginning of the buffer, so the head is buffer[0].next
            // probably null head should be handled at the top of the function
            if (newHead == null) return buffer[0].next;
            else {

                newTail.next = buffer[0].next; // new tail can't be null if new head is not null

                return newHead;

            }

        }

    }

}
