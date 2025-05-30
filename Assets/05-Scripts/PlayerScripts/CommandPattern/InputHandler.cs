using BrickBreaker.State.Player;
using BrickBreaker.State;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerCommand
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 5f;

        private float _moveInput;
        private PlayerStateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine = GetComponent<PlayerStateMachine>();
        }

        private void Update()
        {
            if (_stateMachine.CurrentState is PlayerBaseState || _stateMachine.CurrentState is PlayerGiantState)
            {
                if (_moveInput < 0)
                    new MoveCommand(transform, _moveSpeed, Vector3.left).Execute();
                else if (_moveInput > 0)
                    new MoveCommand(transform, _moveSpeed, Vector3.right).Execute();
            }
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            _moveInput = context.ReadValue<Vector2>().x;
        }
    }
}
