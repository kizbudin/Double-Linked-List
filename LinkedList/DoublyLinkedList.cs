using System;
using System.Collections.Generic;

namespace LinkedList
{
    public enum AddMode
    {
        FirstPosition,
        LastPosition
    }
    /// Kelas node yang menyimpan nilai dan referensi untuk node berikutnya dan sebelumnya.
    /// parameter name="T">Generic type.
    public class DoublyLinkedListNode<T>
    {

        /// Mendapat / menetapkan nilai untuk node saat ini. 

        public T Value { get; set; }

        /// Mendapat / menetapkan referensi ke simpul berikutnya.

        public DoublyLinkedListNode<T> Next { get; set; }

        ///Mendapat / menetapkan referensi ke simpul sebelumnya.

        public DoublyLinkedListNode<T> Previous { get; set; }
       
        /// Default constructor.
        public DoublyLinkedListNode() { }

        /// Konstruktor sekunder yang menerima nilai untuk node saat ini

        public DoublyLinkedListNode(T value)
        {
            Value = value;
        }
    }

    /// Kelas Linked Linked List yang mendukung pengulangan.

    public class DoublyLinkedList<T> : ICollection<T>
    {
        private int _count;
        
        /// Head property.
        
        public DoublyLinkedListNode<T> Head { get; private set; }

       
        /// Tail property.
        
        public DoublyLinkedListNode<T> Tail { get; private set; }

        
        /// menambah data di awal.
       
        //data harus diisi
        public void AddFirst(DoublyLinkedListNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));
            if (_count == 0)
                Head = Tail = node;
            else
            {
                node.Next = Head;
                Head.Previous = node;
                Head = node;
            }
            _count++;
        }


        ///Menambahkan item ke posisi pertama dalam list.
        // parameter name="value"> Item untuk di tambahkan
        public void AddFirst(T value)
        {
            AddFirst(new DoublyLinkedListNode<T>(value));
        }


        /// Menambahkan item ke posisi terakhir dalam list(node).

        public void AddLast(DoublyLinkedListNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));
            if (_count == 0)
                Head = Tail = node;
            else
            {
                node.Previous = Tail;
                Tail.Next = node;
                Tail = node;
            }
            _count++;
        }


        /// Menambahkan item ke posisi terakhir dalam list (isi).


        public void AddLast(T value)
        {
            AddLast(new DoublyLinkedListNode<T>(value));
        }

        /// Menambahkan item setelah simpul yang dipilih. Node yang dipilih tidak boleh nol.
        //'node' tidak boloeh kosong
        /// <exception cref="NullReferenceException">'node' does not exist.</exception>
        public void AddAfter(DoublyLinkedListNode<T> node, T valueToAdd)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));
            if (FindNode(node.Value) == null)
                throw new NullReferenceException("Cannot find a node with the specified 'node' parameter.");
            if (node.Next == null)
                AddLast(new DoublyLinkedListNode<T>(valueToAdd));
            else
            {
                DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(valueToAdd);
                DoublyLinkedListNode<T> currentNext = node.Next;
                node.Next = newNode;
                newNode.Previous = node;
                newNode.Next = currentNext;
                currentNext.Previous = newNode;
                _count++;
            }
        }


        ///Menambahkan item sebelum simpul yang dipilih. Node yang dipilih tidak boleh nol.
        /// <exception cref="ArgumentNullException">'node' cannot be null.</exception>
        /// <exception cref="NullReferenceException">'node' does not exist.</exception>
        public void AddBefore(DoublyLinkedListNode<T> node, T valueToAdd)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));
            if (FindNode(node.Value) == null)
                throw new NullReferenceException("Cannot find a node with the specified 'node' parameter.");
            if (node.Previous == null)
                AddFirst(new DoublyLinkedListNode<T>(valueToAdd));
            else
            {
                DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(valueToAdd);
                DoublyLinkedListNode<T> currentPrev = node.Previous;
                node.Previous = newNode;
                newNode.Next = node;
                newNode.Previous = currentPrev;
                currentPrev.Next = newNode;
                _count++;
            }
        }

       // Menambahkan item ke daftar berdasarkan pilihan yang dipilih dalam AddMode.
       // <parameter name="value">Item untuk menambah. tipe integer.</param>
       // <parameter name="addMode">opsi untuk menambah item.</param>
        public void Add(T value, AddMode addMode)
        {
            switch (addMode)
            {
                case AddMode.FirstPosition:
                    AddFirst(new DoublyLinkedListNode<T>(value));
                    break;
                case AddMode.LastPosition:
                    AddLast(new DoublyLinkedListNode<T>(value));
                    break;
            }
        }

        /// Menghapus item pertama dalam list.
        /// <exception cref="InvalidOperationException">List is empty.</exception>
        public void RemoveFirst()
        {
            if (_count == 0)
                throw new InvalidOperationException("List is empty!");
            if (_count == 1)
                Head = Tail = null;
            else
            {
                Head = Head.Next;
                Head.Previous = null;
            }
            _count--;
        }


        
        /// Menghapus item terakhir linked list
        
        /// <exception cref="InvalidOperationException">List is empty.</exception>
        public void RemoveLast()
        {
            if (_count == 0)
                throw new InvalidOperationException("List is empty!");
            if (_count == 1)
                Head = Tail = null;
            else
            {
                Tail = Tail.Previous;
                Tail.Next = null;
            }
            _count--;
        }

        /// Menemukan simpul dalam daftar.
        
        public DoublyLinkedListNode<T> FindNode(T value)
        {
            if (_count == 0)
                throw new InvalidOperationException("List is empty!");
            DoublyLinkedListNode<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                    return current;
                current = current.Next;
            }
            return null;
        }
        #region ICollection<T>
        /// <summary>
        /// Gets current total items in the list.
        /// </summary>
        public int Count => _count;

        /// <summary>
        /// Gets whether or not list is read only.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Adds an item to the last position in the list.
        /// </summary>
        /// <param name="value">Item to add.</param>
        public void Add(T value)
        {
            AddLast(new DoublyLinkedListNode<T>(value));
        }

        /// <summary>
        /// Removes an item from the list.
        /// </summary>
        /// <param name="value">Item to remove. Generic type.</param>
        /// <returns>True if an item is removed. Otherwise false.</returns>
        /// <exception cref="InvalidOperationException">List is empty.</exception>
        public bool Remove(T value)
        {
            if (_count == 0)
                throw new InvalidOperationException("List is empty!");
            if (Head.Value.Equals(value))
            {
                RemoveFirst();
                return true;
            }
            else if (Tail.Value.Equals(value))
            {
                RemoveLast();
                return true;
            }
            else
            {
                DoublyLinkedListNode<T> current = Head;
                while (current != null)
                {
                    if (current.Value.Equals(value))
                    {
                        DoublyLinkedListNode<T> prev = current.Previous;
                        DoublyLinkedListNode<T> next = current.Next;
                        prev.Next = next;
                        next.Previous = prev;
                        current = null;
                        _count--;
                        return true;
                    }
                    current = current.Next;
                }
            }
            return false;
        }

        /// <summary>
        /// Clears the items in the list.
        /// </summary>
        public void Clear()
        {
            _count = 0;
            Head = Tail = null;
        }

        /// <summary>
        /// Checks whether or not an item exists in the list.
        /// </summary>
        /// <param name="value">Item to check. Generic type.</param>
        /// <returns>True if found. Otherwise false.</returns>
        // <exception cref="InvalidOperationException">List is empty.</exception>
        public bool Contains(T value)
        {
            if (_count == 0)
                throw new InvalidOperationException("List is empty!");
            return FindNode(value) != null;
        }

        /// <summary>
        /// Copies items in the list to array.
        /// </summary>
        /// <param name="array">Array to be copied to.</param>
        /// <param name="arrayIndex">Array start index.</param>
        // <exception cref="InvalidOperationException">List is empty.</exception>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (_count == 0)
                throw new InvalidOperationException("List is empty!");
            DoublyLinkedListNode<T> current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        /// <summary>
        /// Gets IEnumerator of T for current list.
        /// </summary>
        /// <returns>IEnumerator of current generic type.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            DoublyLinkedListNode<T> node = Head;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion
    }
}