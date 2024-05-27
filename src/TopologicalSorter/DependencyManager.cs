using System;

namespace Revvy.TopologicalSorter;

public class DependencyManager
{
	private ISorter _sorter;

	public DependencyManager(ISorter sorter)
	{
		_sorter = sorter;
	}

	public List<int> ResolveDependencies(List<Official> officials)
	{
		return _sorter.Sort(officials);
	}
}
