using UnityEngine;
using UnityEngine.InputSystem;

public class GameState : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActionsAsset;

    [SerializeField] private GameObject _pauseCanvas;

    private IGameState _currentState;
    public IGameState CurrentState => _currentState;

    private InputAction _pauseAction;
    private InputAction _closePausedAction;

    public IGameState WaitingForInput { get; private set; }
    public IGameState BallLaunched { get; private set; }
    public IGameState PausedState { get; private set; }
    public IGameState GameOver { get; private set; }
    public IGameState LevelCleared { get; private set; }

    private void Awake()
    {
        WaitingForInput = new WaitingForInputState();
        BallLaunched = new BallLaunchedState();
        PausedState = new PausedState(_pauseCanvas);
        GameOver = new GameOverState();
        LevelCleared = new LevelClearedState();

        InputActionMap gameplayMap = inputActionsAsset.FindActionMap("Player", true);
        InputActionMap uiMap = inputActionsAsset.FindActionMap("UI", true);

        _pauseAction = gameplayMap.FindAction("Pause");
        _closePausedAction = uiMap.FindAction("ClosePaused");

        if (_pauseAction != null)
        {
            _pauseAction.performed += ctx =>
            {
                if (_currentState == BallLaunched)
                {
                    (BallLaunched as BallLaunchedState)?.OnPauseInput(this);
                }
            };
        }

        if (_closePausedAction != null)
        {
            _closePausedAction.performed += ctx =>
            {
                if (_currentState == PausedState)
                {
                    (PausedState as PausedState)?.OnClosePauseInput(this);
                }
            };
        }
    }

    private void OnEnable()
    {
        _pauseAction?.Enable();
        _closePausedAction?.Enable();
    }

    private void OnDisable()
    {
        _pauseAction?.Disable();
        _closePausedAction?.Disable();
    }

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