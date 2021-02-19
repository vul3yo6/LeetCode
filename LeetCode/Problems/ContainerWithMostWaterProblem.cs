using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Problems
{
    /*
     * Given n non-negative integers a1, a2, ..., an , 
     * where each represents a point at coordinate (i, ai). 
     * n vertical lines are drawn such that the two endpoints of the line i is at (i, ai) and (i, 0). 
     * 
     * Find two lines, which, together with the x-axis forms a container, 
     * such that the container contains the most water.
     * 
     * You may assume that each input would have exactly one solution, and you may not use the same element twice.
     * 
     * Example:
     * 
     * Input: height = [1,8,6,2,5,4,8,3,7]
     * Output: 49
     * Explanation: 
     *      The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7]. 
     *      In this case, the max area of water (blue section) the container can contain is 49.
     */
    public class ContainerWithMostWaterProblem
    {
        public int MaxArea(int[] height)
        {
            if (height.Length < 2)
            {
                return 0;
            }

            // 找出最大的面積
            // 從兩頭開始找, 讓寬度最大; 再比較數值大小, 讓高度最大
            int maxArea = 0;
            int startIndex = 0;
            int endIndex = height.Length - 1;

            while (startIndex < endIndex)
            {
                int area = Math.Min(height[startIndex], height[endIndex]) * (endIndex - startIndex);
                maxArea = Math.Max(maxArea, area);

                if (height[startIndex] > height[endIndex])
                {
                    endIndex--;
                }
                else
                {
                    startIndex++;
                }
            }
            
            return maxArea;
        }
    }
}
