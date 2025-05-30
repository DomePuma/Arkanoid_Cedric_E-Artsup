using BrickBreaker.Ball.Base;
using System;

namespace BrickBreaker.Ball.Type
{
    public class BallBase : ABall
    {
        public static event Action OnBallDeath;

        private GameState _gameState;

        private void OnEnable()
        {
            _gameState = FindFirstObjectByType<GameState>();
            if (_gameState != null)
            {
                _gameState.OnStateChanged += HandleGameStateChanged;
            }
        }

        private void OnDisable()
        {
            if (_gameState != null)
            {
                _gameState.OnStateChanged -= HandleGameStateChanged;
            }
        }

        private void HandleGameStateChanged(IGameState newState)
        {
            if (newState is GameOverState || newState is LevelClearedState)
            {
                Death();
            }
        }

        public override void Death()
        {
            OnBallDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}