using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        //[SerializeField] private Rigidbody2D _rigidbody;
        
        private float _moveInput;

        private void Update()
        {
            Vector3 movement = new Vector3(_moveInput, 0f, 0f) * _speed * Time.deltaTime;

            transform.position += movement;
        }

        public void Move(InputAction.CallbackContext context)
        {
            _moveInput = context.ReadValue<Vector2>().x;
        }
    }
}
