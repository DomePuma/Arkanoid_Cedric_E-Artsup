using UnityEngine;

public class PausedState : IGameState
{
    public void EnterState(GameState gameState)
    {
        Time.timeScale = 0f;
        Debug.Log("État : Pause");
    }

    public void UpdateState(GameState gameState)
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //En attendant
        {
            gameState.SetState(gameState.BallLaunched);
        }
    }

    public void ExitState(GameState gameState)
    {
        Time.timeScale = 1f;
    }
}