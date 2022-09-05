using LinkedList;

var list = new DoublyLinkedList<int>();
list.AddLast(3);   
list.AddLast(1);   
list.AddLast(2);

list.Remove(2);
list.First();
list.QuickSort();

foreach (var item in list)
{
    Console.WriteLine(item);
    Console.WriteLine(list.Last());
}
