using BrickBreaker.BrickDestroyed.Observer;
using BrickBreaker.BrickDestroyed.Subject;
using UnityEngine;

namespace BrickBreaker.Score.Observer
{
    public class ScoreObserver : MonoBehaviour, IBrickDestroyedObserver
    {
        [SerializeField] private int _scorePerBrick = 100;
        
        private ObserverSubject _brickDestroyNotifier;
        private ScoreSystem _scoreSystem;

        private void Awake()
        {
            _scoreSystem = GetComponent<ScoreSystem>();
            _brickDestroyNotifier = FindFirstObjectByType<BrickDestroyNotifier>();
        }

        public void OnNotify(Vector3 brickPosition, int score)
        {
            _scoreSystem.AddScore(score);
        }

        private void OnEnable()
        {
            _brickDestroyNotifier.AddObserver(this);
        }

        private void OnDisable()
        {
            _brickDestroyNotifier.RemoveObserver(this);
        }
    }
}