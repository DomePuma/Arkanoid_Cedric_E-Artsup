using BrickBreaker.Ball.Factory;
using BrickBreaker.Ball.Type;
using UnityEngine;

namespace BrickBreaker.Ball.Spawner
{
    public class BallSpawner : MonoBehaviour
    {
        [SerializeField] private BallType _ballType;
        [SerializeField] private Transform _ballSpwanPoint;

        private GameState _gameState;

        private void Awake()
        {
            _gameState = FindFirstObjectByType<GameState>();
        }

        public void SpawnBall()
        {
            if (_gameState != null && !_gameState.CanSpawnBall) return;

            BallFactory.CreateBall(_ballType, _ballSpwanPoint.position);
        }
    }
}