using BrickBreaker.GameStateSystem;
using BrickBreaker.GameStateSystem.State;
using UnityEngine;

public class GameOverPanelController : MonoBehaviour
{
    private GameState _gameState;

    private void Awake()
    {
        _gameState = FindFirstObjectByType<GameState>();
    }

    public void OpenGameOverPanel()
    {
        gameObject.SetActive(false);

        // Si on est dans l'�tat GameOver, on r�affiche le GameOverCanvas
        if (_gameState.CurrentState is GameOverState)
        {
            _gameState.GameOverCanvas?.SetActive(true);
        }
    }
}