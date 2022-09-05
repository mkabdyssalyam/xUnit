using Xunit;
using System.Linq;

namespace LinkedList.Test
{
    public class DoublyLinkedListTest
    {
        [Fact]
        public void AddFirst()
        {
            var list = new DoublyLinkedList<int>();

            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(3);

            Assert.Equal(3,list.FirstOrDefault());
        }

        [Fact]
        public void AddLast()
        {
            var list = new DoublyLinkedList<int>();

            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            Assert.Equal(3, list.LastOrDefault());
        }

        [Fact]
        public void Remove()
        {
            var list = new DoublyLinkedList<int>();
            list.AddFirst(1);
            list.Remove(1);

            Assert.DoesNotContain(1, list);
        }


        [Fact]
        public void QuickSort()
        {
            var sortedList = new DoublyLinkedList<int>();
            sortedList.AddLast(3);
            sortedList.AddLast(2);
            sortedList.AddLast(1);

            sortedList.AddFirst(4);
            sortedList.AddFirst(5);
            sortedList.AddFirst(6);

            sortedList.QuickSort();

            int i = 1;
            foreach (var item in sortedList)
            {
                Assert.Equal(i, item);
                i++;
            }
        }
    }
}