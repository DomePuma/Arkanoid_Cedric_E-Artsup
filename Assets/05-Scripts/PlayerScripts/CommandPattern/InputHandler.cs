using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerCommand
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;

        private float _moveInput;

        private void Update()
        {
            if (_moveInput < 0)
            {
                var moveCommand = new MoveCommand(transform, moveSpeed, Vector3.left);
                moveCommand.Execute();
            }
            else if (_moveInput > 0)
            {
                var moveCommand = new MoveCommand(transform, moveSpeed, Vector3.right);
                moveCommand.Execute();
            }
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            _moveInput = context.ReadValue<Vector2>().x;
        }
    }
}