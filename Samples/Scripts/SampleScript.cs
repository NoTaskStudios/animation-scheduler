using System.Collections.Generic;
using Notask.AnimationScheduler.Package.Runtime;
using UnityEngine;

namespace Package.Samples.Scripts
{
    public class SampleScript : MonoBehaviour
    {
        [SerializeField] private List<AnimationScheduler> tasks;

        [SerializeField] private Notask.AnimationScheduler.Package.Runtime.Scheduler scheduler;

        private void Start()
        {
            AddTasks(tasks);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                AddTasks(tasks);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayTasks();
            }
        }

        private void AddTasks(List<AnimationScheduler> animationSchedulers)
        {
            foreach (var task in animationSchedulers)
            {
                scheduler.AddScheduler(task);
            }
        }

        private void PlayTasks() => scheduler.PlayScheduler();
    }
}