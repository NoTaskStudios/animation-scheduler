using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class Test : MonoBehaviour
    {
        public PriorityQueue<int> Queue;
        
        public PriorityQueue<int> Queue2;
        
        public PriorityQueue<Anim> Queue3;

        private void Start()
        {
            var list = new List<int> { 2, 9, 7, 6, 5, 8, 10 };
            Queue = new PriorityQueue<int>(list);
            
            var list2 = new List<int> { 2, 9, 7, 6, 5, 8, 10 };
            
            Queue2 = new PriorityQueue<int>(list2, new MaxHeapComparer<int>());
            
            
            var list3 = new List<Anim>
            {
                new Anim { weight = 2 },
                new Anim { weight = 9 },
                new Anim { weight = 7 },
                new Anim { weight = 6 },
                new Anim { weight = 5 },
                new Anim { weight = 8 },
                new Anim { weight = 10 }
            };
            
            Queue3 = new PriorityQueue<Anim>(list3);
        }
    }

    [Serializable]
    public struct Anim : IComparable<Anim>
    {
        public int weight;
        
        public int CompareTo(Anim other) => weight.CompareTo(other.weight);
    }
}