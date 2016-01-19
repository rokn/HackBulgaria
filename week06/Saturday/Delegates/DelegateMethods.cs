using System;
using System.Collections.Generic;

namespace Delegates
{
	public delegate bool FilterDelegate<T>(T element);

	public delegate T AggregationDelegate<T>(T element1, T element2, int pos);

	public delegate bool SortComparer<T>(T element1, T element2);

	public static class DelegateMethods
    {
		// ReSharper disable once TypeParameterCanBeVariant

		public static IEnumerable<T> FilterCollection<T>(this IEnumerable<T> original, FilterDelegate<T> filter)
	    {

			var result = new List<T>();

		    // ReSharper disable once LoopCanBeConvertedToQuery
		    foreach (var element in original)
		    {
			    if (filter(element))
			    {
				    result.Add(element);
			    }
		    }

		    return result;
	    }


		public static T AggregateCollection<T>(this List<T> original, AggregationDelegate<T> aggregate)
		{
			if(original.Count <= 0)
				throw new ArgumentException("List can't be empty");

			var result = original[0];

			for (var i = 1; i < original.Count; i++)
			{
				result = aggregate(result, original[i], i+1);
			}

			return result;
		}

		public static List<T> BubbleSort<T>(this List<T> original, SortComparer<T> comparer)
		{

			for (var i = 0; i < original.Count - 1; i++)
			{
				for (var j = i + 1; j < original.Count; j++)
				{
					if (!comparer(original[i], original[j])) continue;

					var temp = original[i];
					original[i] = original[j];
					original[j] = temp;
				}
			}

			return original;
		}
	}
}



