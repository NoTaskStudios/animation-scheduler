using System;
using System.Collections.Generic;

namespace Notask.AnimationScheduler.Package.Runtime.DataStructure
{
    public class PriorityQueue<TElement>
    {
        private IList<TElement> _heap;
        private IComparer<TElement> _comparer;

        private int InternalNode => (int)Math.Floor(Count / 2.0) - 1;

        public int Count => _heap.Count;

        public int Height => (int)Math.Floor(Math.Log(Count, 2));

        public PriorityQueue() : this(Comparer<TElement>.Default)
        {
        }

        public PriorityQueue(IEnumerable<TElement> collection) : this(collection, Comparer<TElement>.Default)
        {
        }

        public PriorityQueue(IEnumerable<TElement> collection, IComparer<TElement> comparer)
        {
            _heap = new List<TElement>(collection);
            _comparer = comparer;
            BottomUp();
        }

        public PriorityQueue(IComparer<TElement> comparer)
        {
            _heap = new List<TElement>();
            _comparer = comparer;
            BottomUp();
        }

        /// <summary>
        /// Returns the index of the left child of the node at the given index.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private int LeftChild(int i) => 2 * i + 1;

        /// <summary>
        /// create a heap by sifting down the elements.
        /// </summary>
        private void BottomUp()
        {
            if (Count <= 1) return;

            for (var i = InternalNode; i >= 0; i--)
            {
                var k = i;
                var nodeValue = _heap[k];
                var isHeap = false;

                while (!isHeap && LeftChild(k) < Count)
                {
                    var j = LeftChild(k);
                    if (j < Count - 1 && _comparer.Compare(_heap[j], _heap[j + 1]) > 0)
                        j++;

                    if (_comparer.Compare(nodeValue, _heap[j]) <= 0)
                        isHeap = true;
                    else
                    {
                        _heap[k] = _heap[j];
                        k = j;
                    }
                }

                _heap[k] = nodeValue;
            }
        }

        /// <summary>
        /// Adds the given element to the queue.
        /// </summary>
        /// <param name="element"></param>
        public void Enqueue(TElement element)
        {
            _heap.Add(element);
            BottomUp();
        }

        /// <summary>
        /// Removes and returns the element at the front of the queue.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public TElement Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException("Queue is empty");

            var result = _heap[0];
            _heap[0] = _heap[Count - 1];
            _heap.RemoveAt(Count - 1);
            BottomUp();
            return result;
        }

        /// <summary>
        /// Returns the element at the front of the queue without removing it.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public TElement Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("Queue is empty");

            return _heap[0];
        }
    }

    public class MaxHeapComparer<T> : IComparer<T> where T : IComparable<T>
    {
        public int Compare(T x, T y)
        {
            if (Equals(x, null) || Equals(y, null)) throw new ArgumentNullException();

            return y.CompareTo(x);
        }
    }
}