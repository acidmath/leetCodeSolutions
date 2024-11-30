using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePractice {

    internal class Problem21_SetMatrixZeroes : Problem {
        /*
        Given an m x n integer matrix matrix, if an element is 0, set its entire row and column to 0's.

        You must do it in place. 

        Example 1:
        Input: matrix = [[1,1,1],[1,0,1],[1,1,1]]
        Output: [[1,0,1],[0,0,0],[1,0,1]]

        Example 2:
        Input: matrix = [[0,1,2,0],[3,4,5,2],[1,3,1,5]]
        Output: [[0,0,0,0],[0,4,5,0],[0,3,1,0]] 

        Constraints:

        m == matrix.length
        n == matrix[0].length
        1 <= m, n <= 200
        -2^31 <= matrix[i][j] <= 2^31 - 1
 

        Follow up:

        A straightforward solution using O(mn) space is probably a bad idea.
        A simple improvement uses O(m + n) space, but still not the best solution.
        Could you devise a constant space solution?
        */
        internal override void Run() {

            int[][] matrix = getInput(1);

            // print input
            Console.WriteLine("input");
            foreach (int[] row in matrix) {
                Console.WriteLine(string.Join(',', row));
            }

            // print output
            setMatrixZeroesWithRowColBools(matrix);
            Console.WriteLine("output");
            foreach (int[] row in matrix) {
                Console.WriteLine(string.Join(',', row));
            }

        }

        internal int[][] getInput(int exampleNumber) {
            
            switch (exampleNumber) {

                case 1: {
                        int[] row1 = new int[3] { 1, 1, 1 };
                        int[] row2 = new int[3] { 1, 0, 1 };
                        int[] row3 = new int[3] { 1, 1, 1 };
                        return new int[3][] { row1, row2, row3 };
                    }

                case 2: {
                        int[] row1 = new int[4] { 0, 1, 2, 0 };
                        int[] row2 = new int[4] { 3, 4, 5, 2 };
                        int[] row3 = new int[4] { 1, 3, 1, 5 };
                        return new int[3][] { row1, row2, row3 };
                    }

                case 3: {
                        int[] row1 = new int[4] { 7, 1, 2, 8 };
                        int[] row2 = new int[4] { 3, 4, 5, 0 };
                        int[] row3 = new int[4] { 1, 0, 1, 5 };
                        return new int[3][] { row1, row2, row3 };
                    }

                default:
                    return null;

            }

        }

        internal void setMatrixZeroes(ref int[][] matrix) {

            int rowCount = matrix.GetLength(0);
            int columnCount = matrix.GetLength(1);

            // set 0 rows            
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++) {

                // look for a zero, if we find it do like a wiper blade pass
                int columnIndex = 0;
                bool zeroRow = false;
                int direction = 1;
                while (columnIndex > 0 && columnIndex < columnCount) {

                    if(zeroRow) {
                        matrix[rowIndex][columnIndex] = 0;
                        // if we are about to hit the right side of the row, go back to the left
                        if (columnIndex + direction == columnCount) direction = 1;                        
                    }
                    else {
                        zeroRow = matrix[rowIndex][columnIndex]==0;
                    }

                    columnIndex += direction;

                }

            }

        }

        // O(m+n) space
        internal void setMatrixZeroesWithRowColBools(int[][] matrix) {

            int rowCount = matrix.GetLength(0);
            int columnCount = matrix[0].Length;

            bool[] zeroRows = new bool[rowCount];
            bool[] zeroColumns = new bool[columnCount];
         
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++) {

                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++) {

                    if (matrix[rowIndex][columnIndex] == 0) {

                        zeroRows[rowIndex] = true;
                        zeroColumns[columnIndex] = true;

                    }

                }

            }

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++) {

                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++) {

                    if (zeroRows[rowIndex] || zeroColumns[columnIndex]) {

                        matrix[rowIndex][columnIndex] = 0;

                    }

                }

            }

        }

    }

}
