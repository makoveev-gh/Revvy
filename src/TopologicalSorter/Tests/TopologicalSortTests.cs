using NUnit.Framework;

namespace Revvy.TopologicalSorter.Tests;

[TestFixture]
public class TopologicalSortTests
{
	private DependencyManager _manager;

	[SetUp]
	public void Setup()
	{
		_manager = new DependencyManager(new TopologicalSorter());
	}

	[TestCaseSource(nameof(GetSortTestCases))]
	public List<int> TestResolveDependencies(List<Official> officials)
	{
		return _manager.ResolveDependencies(officials);
	}

	private static IEnumerable<TestCaseData> GetSortTestCases()
	{
		yield return new TestCaseData(new List<Official>
		{
			new Official(1, new List<int> { 2 }),
			new Official(2, new List<int> { 3, 4 })
		}).Returns(new List<int> { 4, 3, 2, 1 }).SetName("Dataset - 1");

		yield return new TestCaseData(new List<Official>
		{
			new Official(1, new List<int> { 2 }),
			new Official(3, new List<int> { 4 })
		}).Returns(new List<int> { 4, 2, 3, 1 }).SetName("Dataset - 2");

		yield return new TestCaseData(new List<Official>
		{
			new Official(1, new List<int> { 2 }),
			new Official(2, new List<int> { 3, 4 }),
			new Official(3, new List<int> { 5, 7 })
		}).Returns(new List<int> { 7, 5, 4, 3, 2, 1 }).SetName("Dataset - 3");

		yield return new TestCaseData(new List<Official>
		{
			new Official(3, new List<int> { 2, 4 }),
			new Official(5, new List<int> { 3 })
		}).Returns(new List<int> { 4, 2, 3, 5 }).SetName("Dataset - 4");

		yield return new TestCaseData(new List<Official>
		{
			new Official(5, new List<int> { 3 }),
			new Official(3, new List<int> { 2, 4 })
		}).Returns(new List<int> { 4, 2, 3, 5 }).SetName("Dataset - 5");

		yield return new TestCaseData(new List<Official>
		{
			new Official(2, new List<int> { 3, 4 }),
			new Official(1, new List<int> { 2 })
		}).Returns(new List<int> { 4, 3, 2, 1 }).SetName("Dataset - 6");

		yield return new TestCaseData(new List<Official>
		{
			new Official(2, new List<int> { 3, 4 }),
			new Official(1, new List<int> { 2 }),
			new Official(3, new List<int> { 5, 4 })
		}).Returns(new List<int> { 4, 5, 3, 2, 1 }).SetName("Dataset - 7");
	}
}