using Xunit;
using LeetCode.Problems;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeTests.Problems
{
    public class AprioriAlgorithmProblemTests
    {
        [Fact]
        public void GetResult_IsCurrect_Page19()
        {
            // Arrange
            string filePath = @"Files\AprioriAlgorithmSample";
            //string filePath = @"Files\AprioriAlgorithmData";
            var obj = new AprioriAlgorithmProblem();
            double expected = 0.66;

            // Act
            obj.ReadFile(filePath);
            double actual = obj.GetResult(
                2,
                new List<string>() { "B", "E" }, 
                new List<string>() { "C" });

            // Assert
            Assert.Equal(expected, Math.Round(actual, 2, MidpointRounding.ToNegativeInfinity));
        }

        [Fact]
        public void GetResult_IsCurrect2_Page79()
        {
            // Arrange
            string filePath = @"Files\AprioriAlgorithmSample2";
            var obj = new AprioriAlgorithmProblem();

            // Act
            obj.ReadFile(filePath);
            double actual = obj.GetResult(
                2,
                new List<string>() { "C", "F" },
                new List<string>() { "A", "D" });

            // Assert
            Assert.Equal(0.5, Math.Round(actual, 2, MidpointRounding.ToNegativeInfinity));

            // Act
            obj.ReadFile(filePath);
            actual = obj.GetResult(
                2,
                new List<string>() { "A" },
                new List<string>() { "C", "D", "F" });

            // Assert
            Assert.Equal(0.66, Math.Round(actual, 2, MidpointRounding.ToNegativeInfinity));

            // Act
            obj.ReadFile(filePath);
            actual = obj.GetResult(
                2,
                new List<string>() { "E" },
                new List<string>() { "C", "F" });

            // Assert
            Assert.Equal(0.75, Math.Round(actual, 2, MidpointRounding.ToNegativeInfinity));

            // Act
            obj.ReadFile(filePath);
            actual = obj.GetResult(
                2,
                new List<string>() { "C", "F" },
                new List<string>() { "E" });

            // Assert
            Assert.Equal(0.75, Math.Round(actual, 2, MidpointRounding.ToNegativeInfinity));

            // Act
            obj.ReadFile(filePath);
            actual = obj.GetResult(
                2,
                new List<string>() { "E" },
                new List<string>() { "A" });

            // Assert
            Assert.Equal(0.5, Math.Round(actual, 2, MidpointRounding.ToNegativeInfinity));

            // Act
            obj.ReadFile(filePath);
            actual = obj.GetResult(
                2,
                new List<string>() { "A" },
                new List<string>() { "E" });

            // Assert
            Assert.Equal(0.66, Math.Round(actual, 2, MidpointRounding.ToNegativeInfinity));
        }
    }
}