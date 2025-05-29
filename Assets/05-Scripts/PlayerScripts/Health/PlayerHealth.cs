using BrickBreaker.Ball.Spawner;
using BrickBreaker.Ball.Type;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace BrickBreaker.Player.Health
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private Image[] _heartImages;

        private BallSpawner _ballSpawner;
        private float _lostOpacity = 0.22f;
        private int _currentLives;
        private int _lostLives = 0;

        public event Action OnGameOver;

        private void OnEnable()
        {
            BallBase.OnBallDeath += LoseLife;
        }

        private void OnDisable()
        {
            BallBase.OnBallDeath -= LoseLife;
        }

        private void Awake()
        {
            _ballSpawner = FindFirstObjectByType<BallSpawner>();
        }

        private void Start()
        {
            _currentLives = _heartImages.Length;

            foreach (Image heart in _heartImages)
            {
                SetAlpha(heart, 1f);
            }
        }

        public void LoseLife()
        {
            if (_lostLives >= _heartImages.Length) return;

            SetAlpha(_heartImages[_lostLives], _lostOpacity);
            _lostLives++;
            _currentLives--;

            if (_currentLives > 0)
            {
                _ballSpawner.SpawnBall();
            }
            else
            {
                Debug.Log("Game Over, prévu dans GameState");
                OnGameOver?.Invoke();
            }
        }

        private void SetAlpha(Image image, float alpha)
        {
            Color color = image.color;
            color.a = alpha;
            image.color = color;
        }
    }
}