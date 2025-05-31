using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace BrickBreaker.GameStateSystem.State
{
    public class LevelClearedState : IGameState
    {
        private GameObject _victoryCanvas;
        private InputAction _inputAction;

        public LevelClearedState(GameObject victoryCanvas)
        {
            _victoryCanvas = victoryCanvas;
        }

        public void EnterState(GameState gameState)
        {
            Debug.Log("État : Level cleared !");

            gameState.UIInputMap.Enable();

            if (_victoryCanvas != null)
                _victoryCanvas.SetActive(true);

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

            if (_victoryCanvas != null)
                _victoryCanvas.SetActive(false);

            if (_inputAction != null)
            {
                _inputAction.performed -= OnRestart;
                _inputAction.Disable();
            }
        }
    }
}