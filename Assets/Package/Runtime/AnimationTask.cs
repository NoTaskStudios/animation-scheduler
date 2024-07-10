using System.Collections;
using Notask.AnimationScheduler.Package.Runtime.Helpers;
using UnityEngine;

namespace Notask.AnimationScheduler.Package.Runtime
{
    [DisallowMultipleComponent, RequireComponent(typeof(Animator))]
    internal sealed class AnimationTask : AnimationScheduler
    {
        private Animator _animator;

        public AnimationExecutor<Animator> animationExecutor;
        private void Start() => _animator = GetComponent<Animator>();

        public override void RunSchedule() => StartCoroutine(RunAnim());

        private IEnumerator RunAnim()
        {
            _animator.enabled = true;
            animationExecutor.Anim(_animator);
            yield return new WaitForAnimationToFinish(_animator);
            OnAnimationEnd?.Invoke();
            OnAnimationEnd = null;
        }

        public override void Stop() => _animator.enabled = false;

        public override void Pause() => _animator.speed = 0;

        public override void Resume() => _animator.speed = 1;
    }
}