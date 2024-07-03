using System;
using System.Collections.Generic;
using Notask.AnimationScheduler.Package.Runtime.DataStructure;
using UnityEngine;

namespace Script
{
    public class Test : MonoBehaviour
    {
        private PriorityQueue<int> _queue;

        private PriorityQueue<int> _queue2;

        private void Start()
        {
            var list = new List<int> { 2, 9, 7, 6, 5, 8, 10 };
            _queue = new PriorityQueue<int>(list);

            var list2 = new List<int> { 2, 9, 7, 6, 5, 8, 10 };

            _queue2 = new PriorityQueue<int>(list2, new MaxHeapComparer<int>());
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
                _queue.Dequeue();

            if (Input.GetKeyDown(KeyCode.B))
                _queue2.Dequeue();
        }
    }

    [Serializable]
    public struct Anim : IComparable<Anim>
    {
        public int weight;

        public int CompareTo(Anim other) => weight.CompareTo(other.weight);
    }
}