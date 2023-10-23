namespace CodePractice {

    internal class Problem1_TwoSum : Problem {

        int target = 9;
        int[] input = new int[] { 2, 7, 11, 15 };

        internal override void Run() {

            Console.WriteLine($"Two Sum of [{string.Join(',', input)}] -> [{string.Join(',', TwoSum(input, target))}]");

        }

        /// <summary>
        /// This task implementation turned out to be slower than just a plain array traversal.
        /// </summary>
        int[] TwoSum(int[] nums, int target) {

            int numsCount = nums.Length;
            Task<int[]?>[] tasks = new Task<int[]?>[numsCount];

            int firstNum_Index = 0;
            while (firstNum_Index < numsCount) {
                int _firstNum_Index = firstNum_Index;
                tasks[firstNum_Index] = Task.Run(() => TwoSumTask(nums, _firstNum_Index, target));

                if (firstNum_Index + 1 == numsCount) break;
                firstNum_Index++;

            }

            Task.WaitAll(tasks);
            try {

                return tasks.First(t => t.Result != null).Result;

            }
            catch {

                throw new Exception("I was lied to");

            }

        }

        int[]? TwoSumTask(int[] nums, int firstNum_Index, int target) {
            for (int secondNum_Index = 0; secondNum_Index < nums.Length; secondNum_Index++) {

                if (firstNum_Index == secondNum_Index) continue;

                int firstNum = nums[firstNum_Index];
                int secondNum = nums[secondNum_Index];
                if (firstNum + secondNum == target) {
                    return new int[2] { firstNum_Index, secondNum_Index };
                }
            }

            return default;
        }

    }
}
