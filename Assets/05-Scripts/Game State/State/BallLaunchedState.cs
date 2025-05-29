using UnityEngine;

public class BallLaunchedState : IGameState
{
    private GameObject _pauseCanvas;

    public void EnterState(GameState gameState)
    {
        Debug.Log("�tat : Balle lanc�e");

        _pauseCanvas = GameObject.FindWithTag("PauseCanvas");
        if (_pauseCanvas != null)
        {
            _pauseCanvas.SetActive(false);
        }
    }

    public void UpdateState(GameState gameState)
    {
        // V�rifier les conditions du jeu (ex: victoire)
        // Exemple : if (BrickCount == 0) gameState.SetState(gameState.LevelCleared);
    }

    public void ExitState(GameState gameState) { }

    public void OnPauseInput(GameState gameState)
    {
        if (_pauseCanvas != null)
        {
            _pauseCanvas.SetActive(true);
        }

        gameState.SetState(gameState.Paused);
    }
}