using UnityEngine;
using ScoreObserverPattern;

public class Score : MonoBehaviour, IObserver
{
    [SerializeField] private ObserverSubject _playerSubject;
    [SerializeField] private ScoreSystem _scoreSystem;
    [SerializeField] private int _scorePerBrick = 100;

    public void OnNotify()
    {
        //Debug.Log("Score is NOTIFIED");
        _scoreSystem.AddScore(_scorePerBrick);
    }

    private void OnEnable()
    {
        _playerSubject.AddObserver(this);
    }

    private void OnDisable()
    {
        _playerSubject.RemoveObserver(this);
    }
}
