using algo09_queue;
using System;
using Xunit;

namespace algo09_queue_tests
{
    public class ArrayQueueTests
    {
        [Fact]
        public void Insert_Some_Elements_Then_Verify_Dequeue()
        {
            var arrayQueue = new ArrayQueue(4);
            arrayQueue.Enqueue("a");
            arrayQueue.Enqueue("b");
            arrayQueue.Enqueue("c");

            Assert.Equal("a", arrayQueue.Dequeue());
            Assert.Equal("b", arrayQueue.Dequeue());
            Assert.Equal("c", arrayQueue.Dequeue());
        }


        [Fact]
        public void Insert_Some_Elements_Then_Verify()
        {
            var arrayQueue = new ArrayQueue(7);
            arrayQueue.Enqueue("a");
            arrayQueue.Enqueue("b");
            arrayQueue.Enqueue("c");
            arrayQueue.Enqueue("d");
            arrayQueue.Enqueue("e");
            arrayQueue.Enqueue("f");
            arrayQueue.Enqueue("g");

            arrayQueue.Dequeue();
            arrayQueue.Dequeue();
            arrayQueue.Dequeue();

            arrayQueue.Enqueue("h");
        }

    }
}
