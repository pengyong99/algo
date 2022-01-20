using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo09_queue
{
    // 用数组实现的队列
    public class ArrayQueue
    {
        // 数组：items，数组大小：n
        private readonly string[] items;
        private readonly int n = 0;
        // head表示队头下标，tail表示队尾下标
        private int head = 0;
        private int tail = 0;

        // 申请一个大小为capacity的数组
        public ArrayQueue(int capacity)
        {
            items = new string[capacity];
            n = capacity;
        }


        // 入队操作，将item放入队尾
        public bool Enqueue(string item)
        {
            // tail == n表示队列末尾没有空间了
            if (tail == n)
            {
                // tail ==n && head==0，表示整个队列都占满了
                if (head == 0) return false;
                // 数据搬移
                for (int i = head; i < tail; i++)
                {
                    items[i - head] = items[i];
                }
                // 搬移完之后重新更新head和tail
                tail -= head;
                head = 0;
            }

            items[tail] = item;
            ++tail;
            return true;
        }

        // 出队
        public string Dequeue()
        {
            // 如果head == tail 表示队列为空
            if (head == tail) return null;
            string ret = items[head];
            ++head;
            return ret;
        }

    }
}
