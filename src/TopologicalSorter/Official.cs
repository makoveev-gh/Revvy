using System;

namespace Revvy.TopologicalSorter;

public class Official
{
	public int Id { get; private set; }
	public List<int> Dependencies { get; private set; }

	public Official(int id, List<int> dependencies)
	{
		Id = id;
		Dependencies = dependencies ?? new List<int>();
	}
}
