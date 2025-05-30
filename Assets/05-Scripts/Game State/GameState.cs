using BrickBreaker.Ball.Spawner;
using BrickBreaker.Player.Health;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameState : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActionsAsset;
    [SerializeField] private GameObject _pauseCanvas;
    [SerializeField] private GameObject _gameOverCanvas;

    private IGameState _currentState;
    public IGameState CurrentState => _currentState;

    private InputAction _pauseAction;
    private InputAction _closePausedAction;

    private BallSpawner _ballSpawner;

    private PlayerHealth _playerHealth;
    public PlayerHealth PlayerHealth => _playerHealth;

    public InputActionMap PlayerInputMap => inputActionsAsset.FindActionMap("Player", true);
    public InputActionMap UIInputMap => inputActionsAsset.FindActionMap("UI", true);

    public GameObject GameOverCanvas => _gameOverCanvas;

    public IGameState WaitingForInput { get; private set; }
    public IGameState BallLaunched { get; private set; }
    public IGameState PausedState { get; private set; }
    public IGameState GameOver { get; private set; }
    public IGameState LevelCleared { get; private set; }

    private void Awake()
    {
        _playerHealth = FindFirstObjectByType<PlayerHealth>();
        _ballSpawner = FindFirstObjectByType<BallSpawner>();

        WaitingForInput = new WaitingForInputState();
        BallLaunched = new BallLaunchedState(_pauseCanvas, _ballSpawner);
        PausedState = new PausedState(_pauseCanvas);
        GameOver = new GameOverState();
        LevelCleared = new LevelClearedState();

        _pauseAction = PlayerInputMap.FindAction("Pause");
        _closePausedAction = UIInputMap.FindAction("ClosePaused");

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
        // Abonnné à l’event du premier mouvement
        PlayerCommand.InputHandler.OnInitialMoveInput += HandleInitialMoveInput;

        _pauseAction?.Enable();
        _closePausedAction?.Enable();

        if (_playerHealth != null)
            _playerHealth.OnGameOver += HandleGameOver;
    }

    private void OnDisable()
    {
        PlayerCommand.InputHandler.OnInitialMoveInput -= HandleInitialMoveInput;

        _pauseAction?.Disable();
        _closePausedAction?.Disable();

        if (_playerHealth != null)
            _playerHealth.OnGameOver -= HandleGameOver;
    }

    private void HandleInitialMoveInput()
    {
        if (_currentState == WaitingForInput)
        {
            SetState(BallLaunched);
        }
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

    private void HandleGameOver()
    {
        SetState(GameOver);
    }
}