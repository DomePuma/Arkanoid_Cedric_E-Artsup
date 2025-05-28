using BrickBreaker.Score.Subject;
using UnityEngine;

namespace BrickBreaker.Score.Observer
{
    public class ScoreObserver : MonoBehaviour, IObserver
    {
        [SerializeField] private ScoreSystem _scoreSystem;
        [SerializeField] private ObserverSubject _brickDestroyNotifier;
        [SerializeField] private int _scorePerBrick = 100;

        public void OnNotify()
        {
            _scoreSystem.AddScore(_scorePerBrick);
        }

        private void OnEnable()
        {
            _brickDestroyNotifier.AddObserver(this);
            //BrickDestroyNotifier.Instance.AddObserver(this);
        }

        private void OnDisable()
        {
            _brickDestroyNotifier.RemoveObserver(this);
            //BrickDestroyNotifier.Instance.RemoveObserver(this);
        }
    }
}