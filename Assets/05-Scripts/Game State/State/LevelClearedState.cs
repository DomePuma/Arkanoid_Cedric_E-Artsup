using UnityEngine;

public class LevelClearedState : IGameState
{
    public void EnterState(GameState gameState)
    {
        Debug.Log("État : Level cleared !");
        // Animation, transition au prochain niveau...
    }

    public void UpdateState(GameState gameState) { }

    public void ExitState(GameState gameState) { }
}