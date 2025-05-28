using UnityEngine;
namespace ScoreObserverPattern
{
    public class ScoreObserver : MonoBehaviour, IObserver
    {
        [SerializeField] private ObserverSubject _observerSubject;
        [SerializeField] private ScoreSystem _scoreSystem;
        [SerializeField] private int _scorePerBrick = 100;

        public void OnNotify()
        {
            _scoreSystem.AddScore(_scorePerBrick);
        }

        private void OnEnable()
        {
            _observerSubject.AddObserver(this);
        }

        private void OnDisable()
        {
            _observerSubject.RemoveObserver(this);
        }
    }
}