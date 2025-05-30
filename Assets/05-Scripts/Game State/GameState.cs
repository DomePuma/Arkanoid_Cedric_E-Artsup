using BrickBreaker.Ball.Base;
using BrickBreaker.Ball.Spawner;
using BrickBreaker.GameStateSystem.State;
using BrickBreaker.Player.Health;
using BrickBreaker.Score.Subject;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BrickBreaker.GameStateSystem
{
    public class GameState : MonoBehaviour
    {
        [SerializeField] private InputActionAsset inputActionsAsset;
        [SerializeField] private GameObject _pauseCanvas;
        [SerializeField] private GameObject _gameOverCanvas;
        [SerializeField] private GameObject _victoryCanvas;

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

        public bool CanSpawnBall => !(_currentState is LevelClearedState || _currentState is GameOverState);

        public event Action<IGameState> OnStateChanged;
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
            LevelCleared = new LevelClearedState(_victoryCanvas);

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
            PlayerCommand.InputHandler.OnInitialMoveInput += HandleInitialMoveInput;

            if (BrickDestroyNotifier.Instance == null)
            {
                BrickDestroyNotifier fallback = FindFirstObjectByType<BrickDestroyNotifier>();

                if (fallback != null)
                {
                    Debug.Log("Found fallback BrickDestroyNotifier in scene.");
                    BrickDestroyNotifier.Instance = fallback;

                    fallback.OnAllBricksDestroyed += HandleLevelCleared;
                }
            }

            _pauseAction?.Enable();
            _closePausedAction?.Enable();

            if (_playerHealth != null)
                _playerHealth.OnGameOver += HandleGameOver;
        }

        private void OnDisable()
        {
            PlayerCommand.InputHandler.OnInitialMoveInput -= HandleInitialMoveInput;

            if (BrickDestroyNotifier.Instance != null)
            {
                BrickDestroyNotifier.Instance.OnAllBricksDestroyed -= HandleLevelCleared;
            }
            else
            {
                Debug.LogWarning("BrickDestroyNotifier.Instance is null in GameState.Disable");
            }

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

            OnStateChanged?.Invoke(newState);

            if (_currentState is GameOverState || _currentState is LevelClearedState)
            {
                DestroyAllBalls();
            }
        }

        private void DestroyAllBalls()
        {
            var balls = FindObjectsOfType<ABall>();
            foreach (var ball in balls)
            {
                ball.Death();
            }
        }

        private void HandleGameOver()
        {
            SetState(GameOver);
        }

        private void HandleLevelCleared()
        {
            SetState(LevelCleared);
        }
    }
}