using BrickBreaker.State.Data;
using BrickBreaker.State.Player;
using UnityEngine;

namespace BrickBreaker.State
{
    public class PlayerGiantState : IState
    {
        private Vector3 _originalScale;

        public void Enter(IStateMachineData stateMachineData)
        {
            var data = stateMachineData as PlayerStateMachineData;
            _originalScale = data.PlayerTransform.localScale;
            data.PlayerTransform.localScale = _originalScale * 1.5f;
        }

        public IState Update(IStateMachineData stateMachineData)
        {
            var data = stateMachineData as PlayerStateMachineData;
            var sm = data.PlayerTransform.GetComponent<PlayerStateMachine>();

            if (sm.IsCurrentStateTimedOut())
                return new PlayerBaseState();

            return null;
        }

        public void Exit(IStateMachineData stateMachineData)
        {
            var data = stateMachineData as PlayerStateMachineData;
            data.PlayerTransform.localScale = _originalScale;
        }
    }
}