using BrickBreaker.State;
using BrickBreaker.State.Data;
using UnityEngine;
using BrickBreaker.Ball;

namespace BrickBreaker.State.Player
{
    public class PlayerStateMachine : MonoBehaviour
    {
        private IState _currentState;
        private PlayerStateMachineData _data;
        private float _stateTimer;

        public IState CurrentState => _currentState;

        private void Start()
        {
            _data = new PlayerStateMachineData
            {
                PlayerTransform = transform,
                PlayerScale = transform.localScale
            };

            SwitchState(new PlayerBaseState());
        }

        private void Update()
        {
            if (_currentState != null)
            {
                _stateTimer -= Time.deltaTime;
                var nextState = _currentState.Update(_data);

                if (nextState != null)
                    SwitchState(nextState);
            }
        }

        public void SwitchState(IState newState, float duration = -1f)
        {
            _currentState?.Exit(_data);
            _currentState = newState;
            _stateTimer = duration;
            _currentState.Enter(_data);
        }

        public bool IsCurrentStateTimedOut() => _stateTimer <= 0f;

        public Transform GetBallTransform()
        {
            return BallReference.BallTransform;
        }
    }
}