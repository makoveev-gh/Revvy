using System;

namespace Revvy.TopologicalSorter;

// Интерфейс для алгоритма топологической сортировки
public interface ISorter
{
	public List<int> Sort(List<Official> officials);
}
