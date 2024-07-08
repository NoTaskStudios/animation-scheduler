using UnityEngine;

namespace Notask.AnimationScheduler.Package.Runtime.Helpers
{
    public class WaitForAnimationToFinish : CustomYieldInstruction
    {
        private readonly string _stateAnimName;

        private readonly Animator _animator;
        private readonly int _layerIndex;

        private AnimatorStateInfo StateInfo => _animator.GetCurrentAnimatorStateInfo(_layerIndex);

        private bool CorrectAnimationIsPlaying => StateInfo.IsName(_stateAnimName);

        private bool AnimationIsDone => StateInfo.normalizedTime >= 1;

        public override bool keepWaiting => CorrectAnimationIsPlaying && !AnimationIsDone;


        /// <summary>
        /// Creates a new yield-instruction
        /// </summary>
        /// <param name="animator">The animator to track</param>
        /// <param name="stateAnimName">The name of the animation</param>
        /// <param name="layerIndex">The layer the animation is playing on</param>
        public WaitForAnimationToFinish(Animator animator, string stateAnimName, int layerIndex = 0)
        {
            _animator = animator;
            _layerIndex = layerIndex;
            _stateAnimName = stateAnimName;
        }
    }
}