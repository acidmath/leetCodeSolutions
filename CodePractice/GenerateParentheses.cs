namespace CodePractice {

    /// <summary>
    /// Solution to <see href="https://leetcode.com/problems/generate-parentheses/description/">this problem</see>
    /// </summary>
    internal class GenerateParentheses : Problem {

        /*
        Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses. 

        Example 1:
        Input: n = 3
        Output: ["((()))","(()())","(())()","()(())","()()()"]

        Example 2:
        Input: n = 1
        Output: ["()"] 

        Constraints:
        1 <= n <= 8
        */
        // initial thought is make a cool way to do this
        // and store all the possible variations in a text file
        // and make subsequent runs reference that and pull it up to make the test run super fast
        // because the constraint is low enough
        internal override void Run() {
            if (TryGetInput(out int pairCount)) {
                IList<string> output = GenerateParenthesis(pairCount);
            }
        }

        private bool TryGetInput(out int pairCount) {
            ConsoleKeyInfo input = Console.ReadKey();
            return int.TryParse(input.KeyChar.ToString(), out pairCount);
        }
        // solution to n=4
        // (((()))), ((()())), ((())()), ((()))(), (())(()), (())()(), ()()(()), ()()()(), ()(())(), (()(())), ()((()))
        // 32100123, 21000012, 21001001, 21001200, 10011001, 10010000, 00001001, 00000000, 00100100, 10010012, 00210012
        // 44443210, 44433210, 44432210, 44432110, 44322210, 44322110, 43322210, 43322110, 43332110, 44333210, 43333210
        // solution to n=3
        // ((())), (()()), (())(), ()(()), ()()()
        // 210012, 100001, 100100, 001001, 000000
        // 333210, 332210, 332110, 322210, 322110
        private IList<string> GenerateParenthesis(int n) {
            return new List<string>();
        }
    }
}