using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLinkedListTests
{
    [TestFixture]
    public class MyLinkedListEnumerableTests
    {
        private MyLinkedList<int> list;

        [SetUp]
        public void Setup()
        {
            list = new MyLinkedList<int>();
        }

        [Test]
        public void Foreach_ShouldIterateAllElementsInOrder()
        {
            list.Add(10);
            list.Add(20);
            list.Add(30);

            var result = new List<int>();
            foreach (var item in list)
            {
                result.Add(item);
            }

            CollectionAssert.AreEqual(new[] { 10, 20, 30 }, result);
        }

        [Test]
        public void Enumerator_ShouldWorkWithLinq_ToArray()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);

            int[] result = list.ToArray();

            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, result);
        }

        [Test]
        public void Enumerator_ShouldReturnEmpty_WhenListIsEmpty()
        {
            var result = list.ToArray();

            Assert.AreEqual(0, result.Length);
        }

        [Test]
        public void Enumerator_ShouldAllowMultipleIterations()
        {
            list.Add(5);
            list.Add(6);

            var first = list.ToArray();
            var second = list.ToArray();

            CollectionAssert.AreEqual(first, second);
        }
    }
}



// ANTWOORDEN OP DE VRAGEN

// --------------------------------------------------------------
// 1. Welke methods heeft elk object in .NET?
//
// Elke class in .NET erft van "object". Daardoor heeft alles standaard:
//
// - ToString()    → maakt een tekst van je object
// - Equals(obj)   → kijkt of 2 objecten gelijk zijn
// - GetHashCode() → geeft een getal terug (gebruikt in HashSet/Dictionary)
// - GetType()     → geeft het type terug (bijv. int, string)
//
// --------------------------------------------------------------
// 2. Implementeren List, Dictionary en HashSet IEnumerable?
//
// Ja! Ze implementeren allemaal IEnumerable. Daardoor kan je "foreach" gebruiken.
//
// - List<T>
//   Bewaart dingen in volgorde.
//   Voorbeeld:
//     var list = new List<int> { 1, 2, 3 };
//     foreach (var item in list) Console.WriteLine(item);
//
// - Dictionary<TKey, TValue>
//   Bewaart dingen in paren (key en value).
//   Voorbeeld:
//     var dict = new Dictionary<string, int> { { "a", 1 }, { "b", 2 } };
//     foreach (var kvp in dict) Console.WriteLine(kvp.Key + " = " + kvp.Value);
//
// - HashSet<T>
//   Bewaart alleen unieke dingen (geen dubbele).
//   Volgorde is willekeurig (niet vast).
//   Voorbeeld:
//     var set = new HashSet<int> { 10, 20, 30 };
//     foreach (var item in set) Console.WriteLine(item);
//
// --------------------------------------------------------------
// Conclusie:
// - Elk object in .NET heeft ToString, Equals, GetHashCode en GetType.
// - List, Dictionary en HashSet kunnen allemaal met foreach gebruikt worden.
// --------------------------------------------------------------
