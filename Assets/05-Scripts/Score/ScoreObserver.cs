using BrickBreaker.Score.Subject;
using UnityEngine;

namespace BrickBreaker.Score.Observer
{
    public class ScoreObserver : MonoBehaviour, IObserver
    {
        [SerializeField] private int _scorePerBrick = 100;
        
        private ObserverSubject _brickDestroyNotifier;
        private ScoreSystem _scoreSystem;

        private void Awake()
        {
            _scoreSystem = GetComponent<ScoreSystem>();
            _brickDestroyNotifier = FindFirstObjectByType<BrickDestroyNotifier>();
        }

        public void OnNotify()
        {
            _scoreSystem.AddScore(_scorePerBrick);
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