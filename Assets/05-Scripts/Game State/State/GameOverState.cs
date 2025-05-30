using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameOverState : IGameState
{
    private InputAction _restartAction;

    public void EnterState(GameState gameState)
    {
        Debug.Log("État : Game Over");

        gameState.PlayerInputMap.Disable();
        gameState.UIInputMap.Enable();

        gameState.GameOverCanvas?.SetActive(true);

        _restartAction = gameState.UIInputMap.FindAction("Restart");
        if (_restartAction != null)
        {
            _restartAction.performed += OnRestart;
            _restartAction.Enable();
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

        if (_restartAction != null)
        {
            _restartAction.performed -= OnRestart;
            _restartAction.Disable();
        }
    }
}