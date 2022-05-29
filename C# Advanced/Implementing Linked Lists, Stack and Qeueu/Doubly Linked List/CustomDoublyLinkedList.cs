namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        public static void Main()
        {
            var list = new DoublyLinkedList();
            list.AddFirst(3);
            list.AddFirst(2);
            list.AddFirst(1);
            list.AddLast(4);
            list.AddFirst(0);
            list.AddLast(100);

            list.RemoveFirst();
            list.RemoveLast();
            list.AddLast(5);

            Console.WriteLine(string.Join(" ", list.ToArray()));

        }
    }
}