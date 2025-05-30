using BrickBreaker.Ball.Spawner;
using BrickBreaker.Ball.Type;
using BrickBreaker.BrickDestroyed.Subject;
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

        public static PlayerHealth Instance { get; private set; }
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
            if (Instance == null) Instance = this;
            else Destroy(gameObject);

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

        public void AddLife()
        {
            if(_currentLives <= _heartImages.Length)
            {
                //Il faudra modifier ça, je ne sais pas comment bien le faire ^^'
                SetAlpha(_heartImages[_lostLives], 1f);
                _lostLives--;
                _currentLives++;
            }
            else
            {
                Debug.Log("Max Lives");
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