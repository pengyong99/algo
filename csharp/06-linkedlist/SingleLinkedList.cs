using System;

namespace algo06_linked_list
{
    /// <summary>
    /// 单链表的插入、删除、清空、查找
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingleLinkedList<T> where T : IComparable<T>
    {
        public ListNode<T> First => Head.Next;

        // 哨兵节点
        public ListNode<T> Head { get; }

        // 链表的总长度
        public int Length { get; private set; }

        public SingleLinkedList()
        {
            Head = new ListNode<T>(default);
        }

        public SingleLinkedList(params T[] list)
        {
            // 哨兵节点
            Head = new ListNode<T>(default);
            if (list == null) return;

            ListNode<T> p = Head;
            foreach (var item in list)
            {
                var q = new ListNode<T>(item);
                // p 结点中的 next 指针存储了 q 结点的内存地址。
                p.Next = q;
                p = p.Next;
            }

            Length = list.Length;
        }

        public ListNode<T> Insert(int position, T newElem)
        {
            if (position < 1 || position > Length + 1)
            {
                throw new IndexOutOfRangeException("Position must be in bound of list");
            }

            ListNode<T> p = Head;

            // 遍历链表
            int j = 1;
            while (p != null && j < position)
            {
                p = p.Next;
                j++;
            }

            // 插入指针
            var newNode = new ListNode<T>(newElem);
            newNode.Next = p.Next;
            p.Next = newNode;

            Length++;

            return newNode;
        }

        public ListNode<T> Find(int position)
        {
            ListNode<T> p = First;
            int j = 1;

            while (p != null && j < position)
            {
                p = p.Next;
                j++;
            }

            if (p == null || j > position)
            {
                return null;
            }

            return p;
        }

        public ListNode<T> Find(T elem)
        {
            ListNode<T> p = Head.Next;

            while (p != null)
            {
                if (p.Value.CompareTo(elem) == 0) return p;

                p = p.Next;
            }

            return null;
        }

        /// <summary>
        /// 删除结点中“值等于某个给定值”的结点
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ListNode<T> Delete(T value)
        {
            ListNode<T> cur = Head;
            // 找到要删除结点中“值等于某个给定值”的结点的前驱结点 
            while (cur.Next != null && cur.Next.Value.CompareTo(value) != 0)
            {
                cur = cur.Next;
            }

            // 如果没找到就直接返回null
            if (cur.Next == null) return null;

            // 前驱结点指向删除的结点的下一个结点即可
            ListNode<T> q = cur.Next;
            cur.Next = q.Next;

            Length--;

            return q;
        }

        /// <summary>
        /// 删除给定指针指向的结点
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public ListNode<T> Delete(int position)
        {
            if (position < 1 || position > Length)
            {
                return null;
            }

            ListNode<T> p = First;

            // 找到要删除的结点的前驱结点
            int j = 1;
            while (p != null && j < position - 1)
            {
                p = p.Next;
                j++;
            }

            // 前驱结点指向删除的结点的下一个结点即可
            ListNode<T> q = p.Next;
            p.Next = q.Next;

            Length--;

            return q;
        }

        public void Clear()
        {
            ListNode<T> cur = Head;
            while (cur.Next != null)
            {
                var q = cur.Next;
                cur.Next = null;

                cur = q;
            }

            Length = 0;
        }
    }

    public class ListNode<T>
    {
        public ListNode(T value)
        {
            Value = value;
        }

        public T Value { get; }

        public ListNode<T> Next { get; set; }
    }
}