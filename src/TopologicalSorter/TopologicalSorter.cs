using System;

namespace Revvy.TopologicalSorter;

// Реализация топологической сортировки, алгоритм Кана
public class TopologicalSorter : ISorter
{
	public List<int> Sort(List<Official> officials)
	{
		var inDegree = new Dictionary<int, int>();
		var dependencies = new Dictionary<int, List<int>>();

		foreach(var official in officials)
		{
			if(!inDegree.ContainsKey(official.Id))
				inDegree[official.Id] = 0;

			foreach(var dependency in official.Dependencies)
			{
				if(!inDegree.ContainsKey(dependency))
					inDegree[dependency] = 0;
				inDegree[dependency]++;

				if(!dependencies.ContainsKey(official.Id))
					dependencies[official.Id] = new List<int>();
				dependencies[official.Id].Add(dependency);
			}
		}

		var queue = new Queue<int>(inDegree.Where(kvp => kvp.Value == 0).Select(kvp => kvp.Key));
		var sorted = new List<int>();

		while(queue.Count > 0)
		{
			var current = queue.Dequeue();
			sorted.Insert(0, current); ;

			if(!dependencies.ContainsKey(current)) continue;
			foreach(var dependent in dependencies[current])
			{
				inDegree[dependent]--;
				if(inDegree[dependent] == 0)
					queue.Enqueue(dependent);
			}
		}

		if(sorted.Count != inDegree.Count)
		{
			var unprocessed = inDegree.Where(kvp => kvp.Value != 0).Select(kvp => kvp.Key).ToList();
			Console.WriteLine("Unprocessed officials (part of a cycle): " + string.Join(", ", unprocessed));
			throw new InvalidOperationException("Cycle detected in the graph");
		}

		return sorted;
	}
}
