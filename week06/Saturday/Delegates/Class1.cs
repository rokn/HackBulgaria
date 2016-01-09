using System;
using System.Collections.Generic;

namespace Delegates
{
	public delegate bool FilterDelegate<T>(T element);

	public delegate T AggregationDelegate<T>(T element1, T element2);

	public static class DelegateMethods
    {
		// ReSharper disable once TypeParameterCanBeVariant

		public static List<T> FilterCollection<T>(this List<T> original, FilterDelegate<T> filter)
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

			T result = original[0];

			for (var i = 1; i < original.Count; i++)
			{
				result = aggregate(result, original[i]);
			}

			return result;
		}
	}
}
