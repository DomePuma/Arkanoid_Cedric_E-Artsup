using BrickBreaker.Ball.Spawner;
using UnityEngine;

public class BallLaunchedState : IGameState
{
    private GameObject _pauseCanvas;
    private BallSpawner _ballSpawner;
    private bool _hasSpawnedBall = false;

    public BallLaunchedState(GameObject pauseCanvas, BallSpawner ballSpawner)
    {
        _pauseCanvas = pauseCanvas;
        _ballSpawner = ballSpawner;
    }

    public void EnterState(GameState gameState)
    {
        Debug.Log("État : Balle lancée");

        _pauseCanvas?.SetActive(false);

        if (!_hasSpawnedBall)
        {
            _ballSpawner?.SpawnBall();
            _hasSpawnedBall = true;
        }
    }

    public void UpdateState(GameState gameState) { }

    public void ExitState(GameState gameState) { }

    public void OnPauseInput(GameState gameState)
    {
        _pauseCanvas?.SetActive(true);
        gameState.SetState(gameState.PausedState);
    }
}