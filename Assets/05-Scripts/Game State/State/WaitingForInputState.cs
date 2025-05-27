using UnityEngine;

public class WaitingForInputState : IGameState
{
    public void EnterState(GameState gameState)
    {
        Time.timeScale = 0f;
        Debug.Log("État : Attente input joueur");
    }

    public void UpdateState(GameState gameState)
    {
        gameState.SetState(gameState.BallLaunched);
    }

    public void ExitState(GameState gameState)
    {
        Time.timeScale = 1f;
    }
}