using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace BrickBreaker.GameStateSystem.State
{
    namespace BrickBreaker.GameStateSystem
    {
        public class GameOverState : IGameState
        {
            private InputAction _inputAction;

            public void EnterState(GameState gameState)
            {
                Debug.Log("État : Game Over");

                gameState.UIInputMap.Enable();

                gameState.GameOverCanvas?.SetActive(true);

                _inputAction = gameState.UIInputMap.FindAction("UI");
                if (_inputAction != null)
                {
                    _inputAction.performed += OnRestart;
                    _inputAction.Enable();
                }
            }

            private void OnRestart(InputAction.CallbackContext context)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            public void UpdateState(GameState gameState) { }

            public void ExitState(GameState gameState)
            {
                gameState.PlayerInputMap.Enable();
                gameState.UIInputMap.Disable();

                gameState.GameOverCanvas?.SetActive(false);

                if (_inputAction != null)
                {
                    _inputAction.performed -= OnRestart;
                    _inputAction.Disable();
                }
            }
        }
    }
}