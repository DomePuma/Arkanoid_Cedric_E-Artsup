using UnityEngine;

public class WaitingForInputState : IGameState
{
    public void EnterState(GameState gameState)
    {
        Debug.Log("�tat : Attente input joueur");
    }

    public void UpdateState(GameState gameState)
    {
    }

    public void ExitState(GameState gameState)
    {
    }
}