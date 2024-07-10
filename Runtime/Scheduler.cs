using Notask.AnimationScheduler.Package.Runtime.DataStructure;

namespace Notask.AnimationScheduler.Package.Runtime
{
    public sealed class Scheduler
    {
        private readonly PriorityQueue<AnimationScheduler> _priorityQueue = new();
        private AnimationScheduler _current;

        private bool _isPaused;

        public void AddScheduler(AnimationScheduler scheduler) => _priorityQueue.Enqueue(scheduler);

        public void RemoveScheduler(AnimationScheduler scheduler) => _priorityQueue.Remove(scheduler);

        public void PlayScheduler()
        {
            if (_priorityQueue.Count == 0 || _isPaused) return;

            _current = _priorityQueue.Dequeue();
            _current.OnAnimationEnd += OnCurrentAnimationEnd;
            _current.RunSchedule();
        }

        private void OnCurrentAnimationEnd()
        {
            _current.OnAnimationEnd -= OnCurrentAnimationEnd;
            PlayScheduler();
        }

        public void StopScheduler()
        {
            _current.Stop();
            _priorityQueue.Clear();
        }

        public void PauseScheduler(bool immediate = false)
        {
            if (immediate)
            {
                _current.Pause();
                return;
            }

            _isPaused = true;
        }

        public void ResumeScheduler()
        {
            _isPaused = false;
            _current.Resume();
        }
    }
}