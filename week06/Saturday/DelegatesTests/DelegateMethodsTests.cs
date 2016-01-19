using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Delegates;

namespace Delegates.Tests
{
	[TestClass()]
	public class DelegateMethodsTests
	{
		private List<decimal> numbers;

		[TestInitialize]
		public void TestInit()
		{
			numbers = new List<decimal>() {2,4,6,4,2,6};
		}

		[TestMethod()]
		public void FilterCollectionTest()
		{
			var filtered = numbers.FilterCollection(filter);
			foreach (var i in filtered)
			{
				Assert.AreEqual(i,6);
			}
		}

		[TestMethod()]
		public void AggregateCollectionAverageTest()
		{
			Assert.AreEqual(4, numbers.AggregateCollection(Average));
		}

		[TestMethod()]
		public void AggregateCollectionSumTest()
		{
			Assert.AreEqual(24, numbers.AggregateCollection(Sum));
		}

		[TestMethod()]
		public void BubbleSortTest()
		{
			var sorted = numbers.BubbleSort(myCompare);
			Assert.AreEqual(2, sorted[0]);
			Assert.AreEqual(2, sorted[1]);
			Assert.AreEqual(4, sorted[2]);
			Assert.AreEqual(4, sorted[3]);
			Assert.AreEqual(6, sorted[4]);
			Assert.AreEqual(6, sorted[5]);
		}

		private decimal Sum(decimal a, decimal b, int p)
		{
			return a + b;
		}

		private decimal Average(decimal a, decimal b, int pos)
		{
			return (a * (pos - 1) + b) / pos;
		}

		private bool myCompare(decimal a, decimal b)
		{
			return a > b;
		}

		private bool filter(decimal a)
		{
			return a > 4;
		}
	}
}