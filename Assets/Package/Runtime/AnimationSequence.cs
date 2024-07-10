using DG.Tweening;

namespace Notask.AnimationScheduler.Package.Runtime
{
    internal sealed class AnimationSequence : AnimationScheduler
    {
        private Sequence _sequence;
        public AnimationExecutor<Sequence> animationExecutor;

        private void Awake() => _sequence = DOTween.Sequence();

        #region OnEnable / OnDisable

        private void OnDisable() => _sequence.onComplete -= RunAnim;

        #endregion

        private void RunAnim()
        {
            _sequence.Kill();
            OnAnimationEnd?.Invoke();
            OnAnimationEnd = null;
        }

        public override void RunSchedule()
        {
            _sequence.onComplete += RunAnim;
            animationExecutor.Anim(_sequence);
        }

        public override void Stop() => _sequence.Kill();

        public override void Pause() => _sequence.Pause();

        public override void Resume() => _sequence.Play();
    }
}