using NUnit.Framework;
using AwesomeAssertions;
using System;

namespace MyLinkedListTests
{
    [TestFixture]
    public class MyLinkedListTests
    {
        private MyLinkedList<int> list;

        [SetUp]
        public void Setup()
        {
            list = new MyLinkedList<int>();
        }

        [Test]
        public void NewList_ShouldHaveZeroCount()
        {
            list.Count().Should().Be(0);
        }

        [Test]
        public void Add_ShouldIncreaseCount_AndStoreValues()
        {
            list.Add(10);
            list.Add(20);

            list.Count().Should().Be(2);
            list[0].Should().Be(10);
            list[1].Should().Be(20);
        }

        [Test]
        public void IndexOf_ShouldReturnIndex_OrMinusOne()
        {
            list.Add(10);
            list.Add(20);
            list.Add(30);

            list.IndexOf(20).Should().Be(1);
            list.IndexOf(99).Should().Be(-1);
        }

        [Test]
        public void Contains_ShouldReturnTrue_WhenElementExists()
        {
            list.Add(10);

            list.Contains(10).Should().BeTrue();
            list.Contains(99).Should().BeFalse();
        }

        [Test]
        public void Insert_ShouldPlaceElementAtCorrectPosition()
        {
            list.Add(10);
            list.Add(30);

            list.Insert(1, 20);

            list.Should().ContainInOrder(10, 20, 30);
        }

        [Test]
        public void Remove_ShouldDeleteFirstOccurrence()
        {
            list.Add(10);
            list.Add(20);
            list.Add(30);
            list.Add(20);

            list.Remove(20);

            list.Count().Should().Be(3);
            list[1].Should().Be(30);
        }

        [Test]
        public void Remove_ShouldDoNothing_WhenElementNotFound()
        {
            list.Add(10);
            list.Add(20);

            list.Remove(99);

            list.Should().ContainInOrder(10, 20);
        }

        [Test]
        public void RemoveAt_ShouldDeleteElementAtIndex()
        {
            list.Add(10);
            list.Add(20);
            list.Add(30);

            list.RemoveAt(1);

            list.Should().ContainInOrder(10, 30);
        }

        [Test]
        public void Indexer_ShouldGetAndSetValues()
        {
            list.Add(10);
            list[0] = 99;

            list[0].Should().Be(99);
        }

        [Test]
        public void Clear_ShouldEmptyTheList()
        {
            list.Add(10);
            list.Add(20);

            list.Clear();

            list.Count().Should().Be(0);
        }

        [Test]
        public void Clear_ShouldWorkOnEmptyList()
        {
            list.Clear();

            list.Count().Should().Be(0);
        }

        [Test]
        public void Insert_ShouldThrow_WhenIndexIsInvalid()
        {
            list.Add(10);

            Action act1 = () => list.Insert(-1, 20);
            Action act2 = () => list.Insert(2, 20);

            act1.Should().Throw<ArgumentOutOfRangeException>();
            act2.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void RemoveAt_ShouldThrow_WhenIndexIsInvalid()
        {
            list.Add(10);

            Action act1 = () => list.RemoveAt(-1);
            Action act2 = () => list.RemoveAt(1);

            act1.Should().Throw<ArgumentOutOfRangeException>();
            act2.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void Indexer_ShouldThrow_WhenIndexIsInvalid()
        {
            list.Add(10);

            Action act1 = () => { var x = list[-1]; };
            Action act2 = () => { var x = list[1]; };
            Action act3 = () => { list[-1] = 99; };

            act1.Should().Throw<ArgumentOutOfRangeException>();
            act2.Should().Throw<ArgumentOutOfRangeException>();
            act3.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void Enumerator_ShouldWorkWithForeach()
        {
            list.Add(10);
            list.Add(20);
            list.Add(30);

            var items = new System.Collections.Generic.List<int>();
            foreach (var item in list)
            {
                items.Add(item);
            }

            items.Should().ContainInOrder(10, 20, 30);
        }
    }
}
