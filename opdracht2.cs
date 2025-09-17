using System;
using System.Collections;
using System.Collections.Generic;

public interface IMyList<T> : IEnumerable<T>
{
    void Clear();
    void Add(T element);
    int IndexOf(T element);
    bool Contains(T element);
    void Insert(int index, T element);
    void Remove(T element);
    void RemoveAt(int index);
    T this[int index] { get; set; }
    int Count();
}

public class MyLinkedList<T> : IMyList<T>
{
    // Node of the linked list
    private class Node
    {
        public T Data;
        public Node Next;

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    private Node head;   // first node
    private int count;   // number of elements

    public MyLinkedList()
    {
        head = null;
        count = 0;
    }

    // Helper method: throw exception if index is out of range
    private void ValidateIndex(int index, bool allowEqualCount = false)
    {
        if (index < 0 || (allowEqualCount ? index > count : index >= count))
            throw new ArgumentOutOfRangeException(nameof(index));
    }

    // Helper method: get the node at a specific index
    private Node GetNodeAt(int index)
    {
        ValidateIndex(index);

        Node current = head;
        for (int i = 0; i < index; i++)
        {
            current = current.Next;
        }

        return current;
    }

    // Clear the list
    public void Clear()
    {
        head = null;
        count = 0;
    }

    // Add an element at the end of the list
    public void Add(T element)
    {
        Node newNode = new Node(element);

        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node current = head;
            while (current.Next != null)
                current = current.Next;
            current.Next = newNode;
        }

        count++;
    }

    // Return the index of an element, or -1 if not found
    public int IndexOf(T element)
    {
        Node current = head;
        int index = 0;

        while (current != null)
        {
            if (object.Equals(current.Data, element))
                return index;

            current = current.Next;
            index++;
        }

        return -1;
    }

    // Check if an element exists in the list
    public bool Contains(T element)
    {
        return IndexOf(element) != -1;
    }

    // Insert an element at a specific index
    public void Insert(int index, T element)
    {
        ValidateIndex(index, allowEqualCount: true);

        Node newNode = new Node(element);

        if (index == 0)
        {
            newNode.Next = head;
            head = newNode;
        }
        else
        {
            Node prev = GetNodeAt(index - 1);
            newNode.Next = prev.Next;
            prev.Next = newNode;
        }

        count++;
    }

    // Remove the first occurrence of an element
    public void Remove(T element)
    {
        if (head == null) return;

        if (object.Equals(head.Data, element))
        {
            head = head.Next;
            count--;
            return;
        }

        Node prev = head;
        Node current = head.Next;

        while (current != null && !object.Equals(current.Data, element))
        {
            prev = current;
            current = current.Next;
        }

        if (current != null)
        {
            prev.Next = current.Next;
            count--;
        }
    }

    // Remove the element at a specific index
    public void RemoveAt(int index)
    {
        ValidateIndex(index);

        if (index == 0)
        {
            head = head.Next;
        }
        else
        {
            Node prev = GetNodeAt(index - 1);
            prev.Next = prev.Next.Next;
        }

        count--;
    }

    // Indexer (get/set element at a specific index)
    public T this[int index]
    {
        get => GetNodeAt(index).Data;
        set => GetNodeAt(index).Data = value;
    }

    // Return the number of elements
    public int Count() => count;

    // Allow foreach loop (generic version)
    public IEnumerator<T> GetEnumerator()
    {
        Node current = head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    // Non-generic version of GetEnumerator
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
