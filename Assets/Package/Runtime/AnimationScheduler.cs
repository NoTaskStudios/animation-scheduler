using System;
using UnityEngine;

namespace Notask.AnimationScheduler.Package.Runtime
{
    public abstract class AnimationScheduler : MonoBehaviour, ISchedulerNotifier, IComparable<AnimationScheduler>
    {
        [field: SerializeField] public AnimPriority Priority { get; set; } = AnimPriority.Low;

        public Action OnAnimationEnd { get; set; }

        public abstract void RunSchedule();
        public abstract void Stop();
        public abstract void Pause();
        public abstract void Resume();

        public override string ToString() => $"{Priority}";

        public int CompareTo(AnimationScheduler other) => other == null ? 1 : Priority.CompareTo(other.Priority);

        public override bool Equals(object other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(other, null)) return false;
            if (other.GetType() != GetType()) return false;

            return CompareTo(other as AnimationScheduler) == 0;
        }

        public override int GetHashCode() => Priority.GetHashCode();

        public static bool operator ==(AnimationScheduler left, AnimationScheduler right)
        {
            if (ReferenceEquals(left, null)) return ReferenceEquals(right, null);
            return left.Equals(right);
        }

        public static bool operator !=(AnimationScheduler left, AnimationScheduler right)
        {
            return !(left == right);
        }

        public static bool operator >(AnimationScheduler left, AnimationScheduler right)
        {
            if (ReferenceEquals(left, null)) return true;
            return left.CompareTo(right) > 0;
        }

        public static bool operator <(AnimationScheduler left, AnimationScheduler right)
        {
            if (ReferenceEquals(left, null)) return false;
            return left.CompareTo(right) < 0;
        }

        public static bool operator >=(AnimationScheduler left, AnimationScheduler right)
        {
            return !(left < right);
        }

        public static bool operator <=(AnimationScheduler left, AnimationScheduler right)
        {
            return !(left > right);
        }
    }

    public interface ISchedulerNotifier
    {
        Action OnAnimationEnd { get; set; }
    }

    public enum AnimPriority
    {
        Low = 0,
        Medium = 1,
        High = 2
    }
}