using NUnit.Framework;

namespace Revvy.SubsumSolver;

[TestFixture]
public class SubsumSolverTests
{
	[TestCase(new int[] { 3, 1, 8, 5, 4 }, 10, ExpectedResult = true)]
	[TestCase(new int[] { 3, 1, 8, 5, 4 }, 2, ExpectedResult = false)]
	[TestCase(new int[] { 3, 1, 8, 5, 4 }, 9, ExpectedResult = true)]
	[TestCase(new int[] { 3, 1, 8, 5, 4 }, 20, ExpectedResult = true)]
	[TestCase(new int[] { 5, 5, 15, 10 }, 15, ExpectedResult = true)]
	[TestCase(new int[] { 5, 5, 15, 10 }, 31, ExpectedResult = false)]
	[TestCase(new int[] { 5, 5, 15, 10 }, 25, ExpectedResult = true)]
	[TestCase(new int[] { 5, 5, 15, 10 }, 30, ExpectedResult = true)]
	[TestCase(new int[] { 7, 14, 3, 8, 10 }, 11, ExpectedResult = true)]
	public bool TestCanSum(int[] numbers, int targetSum)
	{
		var solver = new SubsumSolver(numbers);
		return solver.CanSum(targetSum);
	}
}