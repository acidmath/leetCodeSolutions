using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePractice {

    /*
    Given a string s, return the longest 
    palindromic substring in s. 

    Example 1:
    Input: s = "babad"
    Output: "bab"
    Explanation: "aba" is also a valid answer.
    
    Example 2:
    Input: s = "cbbd"
    Output: "bb" 

    Constraints:

    1 <= s.length <= 1000
    s consist of only digits and English letters.
    */

    /// <summary>
    /// This is an optimistic search and I believe it is O(n^2), so not great.
    /// it starts with the start index at the front of the string and the end index at the back of the string, it compares the letters at those indices and if they match bring each one 1 closer and check the letters again
    /// If the letters don't match, we shorten the length of our search by 1. 
    /// We then make some more searches that look through all the possible substrings of that length to see if they are palindromes.
    /// This search count is equal to the shortened length + 1, so our total possible search count would be (n + (n -1) + (n -2) ... (n - n + 1)) 
    /// where n is the length of the string, stopping at a length of 1 since that's going to be a guaranteed palindrome
    /// which is basically O(n * n) since we can ignore subtracting the less influential integers. 
    /// </summary>
    internal class Problem3_LongestPalindromicSubstring : Problem {


        string text = "babad";
        int shortening = 0;

        internal override void Run() {

            Console.WriteLine(findLongestPalindromicSubstring());


        }

        //shortening = 3 |0, end-3| 1, end-2 | 2, end-1 | 3, end-0
        string findLongestPalindromicSubstring() {

            for (int i = 0; i <= shortening; i++) {

                int _start = i;
                int _end = text.Length - 1 + i - shortening;

                if (isPalindrome(_start, _end))
                    return text.Substring(_start, _end - _start + 1);
                else
                    Console.WriteLine($"{text.Substring(_start, _end - _start + 1)} is not a palindrome.");

            }

            shortening++;
            return findLongestPalindromicSubstring();

        }

        bool isPalindrome(int start, int end) {

            while (end - start > 0) {

                if (!lettersMatch(start, end))
                    return false;
                start++;
                end--;

            }

            return true;

        }

        bool lettersMatch(int start, int end) {

            return start == end
                || text[start] == text[end];

        }

    }

}
