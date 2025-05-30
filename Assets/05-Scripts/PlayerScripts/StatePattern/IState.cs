using BrickBreaker.State.Data;
namespace BrickBreaker.State
{
    public interface IState
    {
        public void Enter(IStateMachineData stateMachineData);

        public IState Update(IStateMachineData stateMachineData);

        public void Exit(IStateMachineData stateMachineData);
    }
}