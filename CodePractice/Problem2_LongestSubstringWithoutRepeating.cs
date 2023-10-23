namespace CodePractice {

    /*
    Given a string s, find the length of the longest 
    substring
    without repeating characters. 

    Example 1:
    Input: s = "abcabcbb"
    Output: 3
    Explanation: The answer is "abc", with the length of 3.
    
    Example 2:
    Input: s = "bbbbb"
    Output: 1
    Explanation: The answer is "b", with the length of 1.
    
    Example 3:
    Input: s = "pwwkew"
    Output: 3
    Explanation: The answer is "wke", with the length of 3.
    Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
 

    Constraints:

    0 <= s.length <= 5 * 104
    s consists of English letters, digits, symbols and spaces.
    */

    internal class Problem2_LongestSubstringWithoutRepeating : Problem {

        string input = "pwwkefe";

        private List<char> nonRepeatingChars = new List<char>();

        private int longestCount = 0;

        /// <summary>
        /// Go over each character in the string. 
        /// If the next character is present in the subset @nonRepeatingChars, then remove from the front of @nonRepeatingChars until the next character is no longer present.
        /// Then add the next character to the @nonRepeatingChars list.
        /// If the @nonRepeatingChars list length is greater than the longest list counted previously, set the longest count to the lenght of the @nonRepeatingChars list length.
        /// </summary>
        internal override void Run() {

            for (int i = 0; i < input.Length; i++) {

                while (nonRepeatingChars.Contains(input[i])) {
                    nonRepeatingChars.RemoveAt(0);
                }

                nonRepeatingChars.Add(input[i]);

                if (nonRepeatingChars.Count > longestCount) longestCount = nonRepeatingChars.Count;

            }

            Console.WriteLine(longestCount);

        }

    }

}
