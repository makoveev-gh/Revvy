using System;

namespace Revvy.SubsumSolver;
public class SubsumSolver
{
	private readonly int[] _numbers;

	public SubsumSolver(int[] numbers)
	{
		_numbers = numbers;
	}

	public bool CanSum(int targetSum)
	{
		bool[] isPossibleArray = new bool[targetSum + 1];
		isPossibleArray[0] = true;  // базовый случай: сумма 0 всегда достижима

		foreach(var num in _numbers)
		{
			// Перебираем массив сумм в обратном порядке, чтобы избежать повторного использования чисел
			for(int i = targetSum; i >= num; i--)
			{
				if(isPossibleArray[i - num])
				{
					isPossibleArray[i] = true;
				}
			}
		}

		return isPossibleArray[targetSum];
	}
}
