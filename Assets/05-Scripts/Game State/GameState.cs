using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private IGameState _currentState;
    public IGameState CurrentState => _currentState;

    public readonly IGameState WaitingForInput = new WaitingForInputState();
    public readonly IGameState BallLaunched = new BallLaunchedState();
    public readonly IGameState Paused = new PausedState();
    public readonly IGameState GameOver = new GameOverState();
    public readonly IGameState LevelCleared = new LevelClearedState();

    private void Start()
    {
        SetState(WaitingForInput);
    }

    private void Update()
    {
        _currentState?.UpdateState(this);
    }

    public void SetState(IGameState newState)
    {
        _currentState?.ExitState(this);
        _currentState = newState;
        _currentState?.EnterState(this);
    }

    
}