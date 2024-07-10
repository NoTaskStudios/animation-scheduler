using Notask.AnimationScheduler.Package.Runtime;
using UnityEngine;

namespace Package.Samples.Scripts
{
    public abstract class AnimatorExecutor : AnimationExecutor<Animator>
    {
        //empty design pattern
    }

    [CreateAssetMenu(fileName = "AnimatorExecutor", menuName = "Animation Scheduler/AnimatorExecutor")]
    public class AnimatorExecutorExample : AnimatorExecutor
    {
        [SerializeField] private string triggerName = "start";

        public override void Anim(Animator component)
        {
            component.SetTrigger(triggerName);
        }
    }
}