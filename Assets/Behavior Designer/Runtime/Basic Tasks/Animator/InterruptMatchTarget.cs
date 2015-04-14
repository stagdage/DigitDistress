using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAnimator
{
    [TaskCategory("Basic/Animator")]
    [TaskDescription("Interrupts the automatic target matching. Returns Success.")]
    public class InterruptMatchTarget : Action
    {
        [Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
        public SharedGameObject targetGameObject;
        [Tooltip("CompleteMatch will make the gameobject match the target completely at the next frame")]
        public bool completeMatch = true;

        private Animator animator;

        public override void OnStart()
        {
            animator = GetDefaultGameObject(targetGameObject.Value).GetComponent<Animator>();
        }

        public override TaskStatus OnUpdate()
        {
            if (animator == null) {
                Debug.LogWarning("Animator is null");
                return TaskStatus.Failure;
            }

            animator.InterruptMatchTarget(completeMatch);

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            targetGameObject = null;
            completeMatch = true;
        }
    }
}