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
            BrickDestroyNotifier.Instance.AddObserver(this);
        }

        private void OnDisable()
        {
            BrickDestroyNotifier.Instance.RemoveObserver(this);
        }
    }
}