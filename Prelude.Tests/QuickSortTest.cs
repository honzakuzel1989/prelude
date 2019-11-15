using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace System.Prelude.Tests
{
    public class QuickSortTest
    {
        [Test]
        public void WordsTest()
        {
            var x = new []{-66,2,6,4,2,8,5,69,-1,4,8};
            Assert.That(QuickSort(x), Is.EqualTo(new int[]{-66,-1,2,2,4,4,5,6,8,8,69}));
        }

        public static IEnumerable<A> QuickSort<A>(IEnumerable<A> xs) where A : IComparable
        {
            return xs.Any() ? 
                new []{
                    QuickSort(xs.Tail().Filter(x => x.CompareTo(xs.Head()) < 0)),
                    xs.Head().Replicate(1),
                    QuickSort(xs.Tail().Filter(x => x.CompareTo(xs.Head()) >= 0))
                }.Concat()
                : Enumerable.Empty<A>();
        }
    }
}