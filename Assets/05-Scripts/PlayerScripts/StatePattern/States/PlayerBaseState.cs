using BrickBreaker.State.Data;

namespace BrickBreaker.State
{
    public class PlayerBaseState : IState
    {
        public void Enter(IStateMachineData stateMachineData) { }

        public IState Update(IStateMachineData stateMachineData)
        {
            return null;
        }

        public void Exit(IStateMachineData stateMachineData) { }
    }
}