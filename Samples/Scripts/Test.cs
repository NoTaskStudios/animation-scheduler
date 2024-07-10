using System.Collections;
using System.Collections.Generic;
using Notask.AnimationScheduler.Package.Runtime;
using Notask.AnimationScheduler.Package.Runtime.DataStructure;
using Notask.AnimationScheduler.Package.Runtime.Helpers;
using UnityEngine;

namespace Package.Samples.Scripts
{
    public class Test : MonoBehaviour
    {
        private PriorityQueue<AnimationScheduler> queue3;

        public List<AnimationScheduler> animationSchedulers;

        public AnimationScheduler toEnqueue;

        private void Start()
        {
            queue3 = new PriorityQueue<AnimationScheduler>(animationSchedulers);

            Debug.LogWarning(queue3);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.D) && queue3.Count > 0)
            {
                Debug.LogWarning($"dequeue {queue3.Dequeue()} \n {queue3}");
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                queue3.Enqueue(toEnqueue);
                Debug.LogWarning($"enqueue element {toEnqueue}\n {queue3}");
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(WaitTest());
            }
        }

        public Animator animator;

        private IEnumerator WaitTest()
        {
            animator.Play("Test");
            yield return new WaitForAnimationToFinish(animator, "Test");
            Debug.LogWarning("Animation finished");
        }
    }
}