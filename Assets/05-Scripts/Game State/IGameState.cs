namespace BrickBreaker.GameStateSystem
{
    public interface IGameState
    {
        void EnterState(GameState gameState);
        void UpdateState(GameState gameState);
        void ExitState(GameState gameState);
    }
}