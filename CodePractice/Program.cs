using CodePractice;

void getProblem() {
    foreach (PROBLEM problem in Enum.GetValues(typeof(PROBLEM))) {

        Console.WriteLine($"{(int)problem}) {problem}");

    }

    string? problemChosen_s = Console.ReadLine();

    if (int.TryParse(problemChosen_s, out int problemChosen) && Enum.IsDefined(typeof(PROBLEM), problemChosen)) {

        Problem problem;

        switch (problemChosen) {

            case (int)PROBLEM.TWOSUM:
                problem = new Problem1_TwoSum();
                break;

            case (int)PROBLEM.LONGEST_SUBSTRING_WITHOUT_REPEATING:
                problem = new Problem2_LongestSubstringWithoutRepeating();
                break;

            case (int)PROBLEM.LONGEST_PALINDROMIC_SUBSTRING:
                problem = new Problem3_LongestPalindromicSubstring();
                break;

            case (int)PROBLEM.REMOVE_NTH_NODE:
                problem = new Problem6_RemoveNthNode();
                break;

            default:
                throw new Exception("somehow the input validation failed");

        }

        problem.Run();

    }
    else {

        getProblem();

    }

}

getProblem();

/// <summary>
/// Problems coming from this list
/// https://leetcode.com/list/xoqag3yj/
/// </summary>
enum PROBLEM {
    TWOSUM,
    LONGEST_SUBSTRING_WITHOUT_REPEATING,
    LONGEST_PALINDROMIC_SUBSTRING,
    REMOVE_NTH_NODE
}