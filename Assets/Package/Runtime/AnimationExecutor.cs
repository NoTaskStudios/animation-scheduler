using UnityEngine;

namespace Notask.AnimationScheduler.Package.Runtime
{
    public abstract class AnimationExecutor<T> : ScriptableObject
    {
        public abstract void Anim(T component);
    }
}