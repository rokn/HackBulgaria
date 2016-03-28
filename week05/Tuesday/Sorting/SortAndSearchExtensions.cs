using System.Collections.Generic;

namespace Sorting
{
	public static class SortAndSearchExtensions
	{
		public static IList<T> BubbleSort<T>(this IList<T> list, IComparer<T> comparer)
		{
			for (var i = 0; i < list.Count - 2; i++)
			{
				for (var j = i + 1; j < list.Count - 1; j++)
				{
					if (comparer.Compare(list[i], list[j]) > 0)
					{
						var temp = list[i];
						list[i] = list[j];
						list[j] = temp;
					}
				}
			}

			return list;
		}

		public static IList<T> BubbleSort<T>(this IList<T> list)
		{
			return BubbleSort(list, Comparer<T>.Default);
		}

		public static IList<T> SelectionSort<T>(this IList<T> list, IComparer<T> comparer)
		{
			var minIndex = 0;

			for(var i = 0; i < list.Count - 2; i++)
			{
				for(var j = i + 1; j < list.Count - 1; j++)
				{
					if(comparer.Compare(list[minIndex], list[j]) > 0)
					{
						minIndex = j;
					}
				}

				if(i == minIndex) continue;

				var temp = list[i];
				list[i] = list[minIndex];
				list[minIndex] = temp;
			}

			return list;
		}

		public static IList<T> SelectionSort<T>(this IList<T> list)
		{
			return SelectionSort(list, Comparer<T>.Default);
		}


	}
}
