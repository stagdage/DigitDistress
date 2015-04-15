using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables
{
    [TaskCategory("Basic/SharedVariable")]
    [TaskDescription("Sets the SharedObject variable to the specified object. Returns Success.")]
    public class SetSharedObject : Action
    {
        [Tooltip("The value to set the SharedObject to")]
        public SharedObject targetValue;
        [Tooltip("The SharedTransform to set")]
        public SharedObject targetVariable;

        public override TaskStatus OnUpdate()
        {
            targetVariable.Value = targetValue.Value;

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            targetValue = null;
            targetVariable = null;
        }
    }
}