using System.Collections.Generic;
using Notask.AnimationScheduler.Package.Runtime;
using UnityEngine;

namespace Package.Samples.Scripts
{
    public class SampleScript : MonoBehaviour
    {
        [SerializeField] private List<AnimationScheduler> tasks;

        private readonly Scheduler _scheduler = new();

        private void Start()
        {
            AddTasks(tasks);
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.E))
                AddTasks(tasks);
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayTasks();
            }
        }

        private void AddTasks(List<AnimationScheduler> animationSchedulers)
        {
            foreach (var task in animationSchedulers)
            {
                _scheduler.AddScheduler(task);
            }
        }

        private void PlayTasks() => _scheduler.PlayScheduler();
    }
}