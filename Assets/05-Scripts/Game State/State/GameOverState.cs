using UnityEngine;

public class GameOverState : IGameState
{
    public void EnterState(GameState gameState)
    {
        Debug.Log("État : Game Over");
        // Afficher écran game over, attendre restart
    }

    public void UpdateState(GameState gameState)
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Restart
        }
    }

    public void ExitState(GameState gameState) { }
}