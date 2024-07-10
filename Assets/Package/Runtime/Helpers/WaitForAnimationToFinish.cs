using UnityEngine;

namespace Notask.AnimationScheduler.Package.Runtime.Helpers
{
    public class WaitForAnimationToFinish : CustomYieldInstruction
    {
        private readonly string _stateAnimName;
        private readonly Animator _animator;
        private readonly int _layerIndex;

        private bool _hasStarted;

        public override bool keepWaiting
        {
            get
            {
                var stateInfo = _animator.GetCurrentAnimatorStateInfo(_layerIndex);
                var correctAnimationIsPlaying = stateInfo.IsName(_stateAnimName);
                var animationIsDone = stateInfo.normalizedTime >= 1;

                if (_hasStarted) return correctAnimationIsPlaying && !animationIsDone;
                
                if (correctAnimationIsPlaying) _hasStarted = true;
                return true;
            }
        }
        
        /// <summary>
        /// Creates a new yield-instruction
        /// </summary>
        /// <param name="animator">The animator reference.</param>
        /// <param name="stateAnimName">The name of the state of animator, default state value is "Start".</param>
        /// <param name="layerIndex">The layer in animator where the animation is playing on and default value is 0.</param>
        public WaitForAnimationToFinish(Animator animator, string stateAnimName = "Start", int layerIndex = 0)
        {
            _animator = animator;
            _layerIndex = layerIndex;
            _stateAnimName = stateAnimName;
        }
    }
}