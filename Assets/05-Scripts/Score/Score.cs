using System;
using UnityEngine;
using ScoreObserverPattern;

public class Score : MonoBehaviour, IObserver
{
    [SerializeField] ObserverSubject _playerSubject;
    public void OnNotify()
    {
        Debug.Log("Score is NOTIFIED");
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
