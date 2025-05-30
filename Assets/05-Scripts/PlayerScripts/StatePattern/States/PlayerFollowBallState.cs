using BrickBreaker.State.Data;
using BrickBreaker.State.Player;
using UnityEngine;

namespace BrickBreaker.State
{
    public class PlayerFollowBallState : IState
    {
        public void Enter(IStateMachineData stateMachineData) { }

        public IState Update(IStateMachineData stateMachineData)
        {
            var data = stateMachineData as PlayerStateMachineData;
            var sm = data.PlayerTransform.GetComponent<PlayerStateMachine>();
            var ball = sm.GetBallTransform();

            if (sm.IsCurrentStateTimedOut())
                return new PlayerBaseState();

            Vector3 pos = data.PlayerTransform.position;
            pos.x = Mathf.MoveTowards(pos.x, ball.position.x, 10f * Time.deltaTime);
            data.PlayerTransform.position = pos;

            return null;
        }

        public void Exit(IStateMachineData stateMachineData) { }
    }
}