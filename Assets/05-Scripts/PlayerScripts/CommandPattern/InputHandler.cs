using BrickBreaker.GameStateSystem;
using BrickBreaker.GameStateSystem.State;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerCommand
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 5f;

        private float _moveInput;
        private GameState _gameState;
        private bool _hasMoved = false;

        // Event déclenché dès que le joueur bouge pour la première fois
        public static event System.Action OnInitialMoveInput;

        private void Awake()
        {
            _gameState = FindFirstObjectByType<GameState>();
        }

        private void Update()
        {
            if (!(_gameState.CurrentState is BallLaunchedState)) return;

            if (_moveInput < 0)
            {
                var moveCommand = new MoveCommand(transform, _moveSpeed, Vector3.left);
                moveCommand.Execute();
            }
            else if (_moveInput > 0)
            {
                var moveCommand = new MoveCommand(transform, _moveSpeed, Vector3.right);
                moveCommand.Execute();
            }
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            _moveInput = context.ReadValue<Vector2>().x;

            if (!_hasMoved && Mathf.Abs(_moveInput) > 0.1f)
            {
                _hasMoved = true;
                OnInitialMoveInput?.Invoke();
            }
        }
    }
}