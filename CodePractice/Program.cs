using CodePractice;

Dictionary<PROBLEM, Type> Problems = new(){ 
    { PROBLEM.QUIT, typeof(Quit) },
    { PROBLEM.TWOSUM, typeof(Problem1_TwoSum) },
    { PROBLEM.LONGEST_SUBSTRING_WITHOUT_REPEATING, typeof(Problem2_LongestSubstringWithoutRepeating) },
    { PROBLEM.LONGEST_PALINDROMIC_SUBSTRING, typeof(Problem3_LongestPalindromicSubstring) },
    { PROBLEM.REMOVE_NTH_NODE, typeof(Problem6_RemoveNthNode) },    
    { PROBLEM.SET_MATRIX_ZEROES, typeof(Problem21_SetMatrixZeroes) },
    { PROBLEM.VALIDATE_BINARY_SEARCH_TREE, typeof(Problem25_ValidateBinarySearchTree) },
    { PROBLEM.MERGE_TWO_SORTED_LISTS, typeof(MergeTwoSortedLists) }
};

void GetProblem() {
    PrintProblems();

    string? problemChosenInput = Console.ReadLine();
    bool validInt = int.TryParse(problemChosenInput, out int problemChosen);
    bool validProblem = Problems.TryGetValue((PROBLEM)problemChosen, out Type? problemType) && problemType!=null;
    bool validInput = validInt && validProblem;
    if (validInput) {
        Problem? problem = Activator.CreateInstance(problemType!) as Problem;
        if (problem == null) throw new NullReferenceException($"problem type {problemType} could not be resolved");
        Console.Clear();
        problem.Run();        
    }
    else {
        Console.WriteLine($"{problemChosen} is not a valid selection");        
    }

    Console.WriteLine("Press any key to return to the problem menu");
    Console.ReadKey();
    GetProblem();
}

void PrintProblems() {
    Console.Clear();
    foreach (PROBLEM problem in Enum.GetValues(typeof(PROBLEM))) {
        Console.WriteLine($"{(int)problem}) {problem}");
    }
}

GetProblem();

/// <summary>
/// Problems coming from this list
/// https://leetcode.com/list/xoqag3yj/
/// outdated as of 2024-11-30
/// </summary>
enum PROBLEM {
    QUIT,
    TWOSUM,
    LONGEST_SUBSTRING_WITHOUT_REPEATING,
    LONGEST_PALINDROMIC_SUBSTRING,
    REMOVE_NTH_NODE,
    SET_MATRIX_ZEROES,
    VALIDATE_BINARY_SEARCH_TREE,
    MERGE_TWO_SORTED_LISTS
}