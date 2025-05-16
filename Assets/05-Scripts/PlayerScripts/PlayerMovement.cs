using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private Rigidbody2D _rigidbody;
        
        private float _moveInput;

        private void Update()
        {
            _rigidbody.linearVelocity = new Vector2(_moveInput * _speed, _rigidbody.linearVelocity.y);
        }

        public void Move(InputAction.CallbackContext context)
        {
            _moveInput = context.ReadValue<Vector2>().x;
        }
    }
}
